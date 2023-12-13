function checkDeliveryData() {
    const userData = getUserDataFromLocalStorage();

    if (!userData || !userData.address || !userData.city || !userData.state) {
        alert('Please provide delivery information.');
        window.location.href = 'profile.html'; 
    }
}

function getUserDataFromLocalStorage() {
    const userData = JSON.parse(localStorage.getItem('user')) || {};
    return userData;
}

async function getUserData() {
    const token = localStorage.getItem('token');

    if (!token) {
        console.error('The token was not found. The user is not authenticated.');
        return;
    }

    try {
        const response = await fetch('https://localhost:7291/User/Profile', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`,
            },
        });

        if (response.ok) {
            const userData = await response.json();
            console.log('User data:', userData);
            localStorage.setItem('user', JSON.stringify(userData));
            checkDeliveryData();
        } else {
            const errorText = await response.text();
            console.error('Error when receiving user data:', errorText);
        }
    } catch (error) {
        console.error('An error has occurred:', error);
    }
}

document.addEventListener("DOMContentLoaded", async () => {
    await getUserData();
    displayBasketItems();
});

function displayBasketItems() {
    const basketItemsContainer = document.getElementById('basketItemsContainer');
    const totalItemsSpan = document.getElementById('totalItems');
    const totalPriceSpan = document.getElementById('totalPrice');

    const basket = JSON.parse(localStorage.getItem('basket')) || { items: [] };

    basketItemsContainer.innerHTML = '';

    basket.items.forEach(item => {
        const card = document.createElement('div');
        card.classList.add('col');
        card.innerHTML = `
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">${item.name}</h5>
                    <p class="card-text">Memory: ${item.memory}</p>
                    <p class="card-text">Color: ${item.color}</p>
                    <p class="card-text"><strong>$${item.price.toFixed(2)}</strong></p>
                    <button class="btn btn-outline-danger removeFromBasketBtn" data-product-id="${item.id}">Remove</button>
                </div>
            </div>
        `;
        basketItemsContainer.appendChild(card);
    });

    totalItemsSpan.innerText = basket.items.length;
    const totalPrice = basket.items.reduce((sum, item) => sum + item.price, 0);
    totalPriceSpan.innerText = totalPrice.toFixed(2);
}

document.addEventListener("DOMContentLoaded", () => {
    displayBasketItems();
});

document.addEventListener('click', (event) => {
    if (event.target.classList.contains('removeFromBasketBtn')) {
        const productId = event.target.getAttribute('data-product-id');

        let basket = JSON.parse(localStorage.getItem('basket')) || { items: [] };

        basket.items = basket.items.filter(item => item.id !== productId);

        localStorage.setItem('basket', JSON.stringify(basket));

        displayBasketItems();
    }
});

async function placeOrder() {
    const token = localStorage.getItem('token');

    if (!token) {
        console.error('The token was not found. The user is not authenticated.');
        return;
    }

    checkDeliveryData();

    const basket = JSON.parse(localStorage.getItem('basket')) || { items: [] };
    const paymentDropdown = document.getElementById('paymentDropdown');
    const deliveryDropdown = document.getElementById('deliveryDropdown');
    const quantity = document.getElementById('quantity').value;

    if (quantity.trim() === '') {
        alert('Quantity is required.');
        showError('Quantity is required.');
        return;
    }

    const quantityValue = parseInt(quantity);
    if (quantityValue < 1 || quantityValue > 15) {
        alert('Quantity must be between 1 and 15');
        return;
    }

    if (basket.items.length === 0) {
        alert('Your basket is empty. Add items before placing an order.');
        return;
    }

    const paymentId = parseInt(paymentDropdown.value);
    const deliverId = parseInt(deliveryDropdown.value);

    const orderData = {
        listProductId: basket.items.map(item => item.id),
        paymentId: paymentId,
        deliverId: deliverId,
        quantity: quantityValue, 
    };

    try {
        const response = await fetch('https://localhost:7291/User/Order', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`,
            },
            body: JSON.stringify(orderData),
        });

        if (!response.ok) {
            const data = await response.json();
            throw new Error(`Error placing order: ${data.message}`);
        }

        localStorage.removeItem('basket');
        displayBasketItems();
        alert('Order placed successfully!');
    } catch (error) {
        console.error('Error placing order:', error);
        alert('Error placing order. Please try again.');
    }
    
    if (logoutTab) {
        logoutTab.addEventListener('click', () => {
            localStorage.removeItem('token');

            location.reload();
        });
    }
}

