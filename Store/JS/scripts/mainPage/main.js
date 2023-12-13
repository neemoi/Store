document.addEventListener("DOMContentLoaded", () => {
    const token = localStorage.getItem('token');
    console.log('Token:', token);

    const profileTab = document.getElementById('profileTab');
    const basketTab = document.getElementById('basketTab');
    const orderTab = document.getElementById('orderTab');
    const adminDropdown = document.getElementById('adminDropdown');
    const loginTab = document.getElementById('loginTab');
    const registerTab = document.getElementById('registerTab');
    const logoutTab = document.getElementById('logoutTab');

    if (token) {
        const decodedToken = parseJwt(token);
        console.log('The decoded token:', decodedToken);

        const userId = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
        console.log('ID user:', userId);

        if (userId === 'e532e613-6ebb-4bff-abee-4eda9e69f13d') {            //Admin
            if (profileTab && basketTab && adminDropdown) {
                profileTab.style.display = 'block';
                basketTab.style.display = 'block';
                adminDropdown.style.display = 'block';
                orderTab.style.display = 'block';
            }
        } else {
            if (profileTab && basketTab && adminDropdown) {
                profileTab.style.display = 'block';
                basketTab.style.display = 'block';
                orderTab.style.display = 'block';
                adminDropdown.style.display = 'none';
            }
        }

        if (loginTab && registerTab && logoutTab) {
            loginTab.style.display = 'none';
            registerTab.style.display = 'none';
            logoutTab.style.display = 'block';
        } else {
            console.error('One or more items were not found.');
        }
    } else {
        console.error('The user is not authenticated');

        if (profileTab && basketTab && adminDropdown) {
            profileTab.style.display = 'none';
            basketTab.style.display = 'none';
            orderTab.style.display = 'none';
            adminDropdown.style.display = 'none';
        } else {
            console.error('One or more items were not found.');
        }

        if (logoutTab) {
            logoutTab.style.display = 'none';
        }
    }

    if (logoutTab) {
        logoutTab.addEventListener('click', () => {
            localStorage.removeItem('token');

            location.reload();
        });
    }
});

function parseJwt(token) {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(c => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)).join(''));
    return JSON.parse(jsonPayload);
}

document.addEventListener("DOMContentLoaded", async () => {
    try {
        const response = await fetch('https://localhost:7291/User/Order/Product');
        const data = await response.json();

        if (!response.ok) {
            throw new Error(`Error when receiving product data: ${data.message}`);
        }

        const productContainer = document.querySelector('.row');

        data.forEach(product => {
            const productBlock = document.createElement('div');
            productBlock.classList.add('col-md-4', 'mb-3');

            productBlock.innerHTML = `
                <div class="card">
                    <img src="Images/Pixel 8 pro lemongrass.jpg" class="card-img-top" alt="${product.name}">
                    <div class="card-body d-flex flex-column justify-content-between">
                        <h5 class="card-title text-center mb-4">${product.name}</h5>
                        <p class="card-text mb-3">Price: ${product.price ? `$${product.price}` : 'Not available'}</p>
                        <p class="card-text mb-3">Memory: ${product.memory}</p>
                        <p class="card-text mb-3">Color: ${product.color}</p>
                        <p class="card-text mb-4">Category: ${product.categoryName}</p>
                        <button class="btn btn-secondary addToBasketBtn" data-product-id="${product.id}" data-price="${product.price}">Buy now</button>
                    </div>
                </div>
            `;

            productContainer.appendChild(productBlock);
        });
    } catch (error) {
        console.error('An error occurred while downloading the products:', error);
    }
});


