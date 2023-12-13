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
            productBlock.classList.add('col-4', 'mb-3'); // Use col-4 for a fixed size

            let imagePath;
            switch (product.categoryName.toLowerCase()) {
                case 'phone':
                    imagePath = 'Images/Phone.jpg';
                    break;
                case 'watch':
                    imagePath = 'Images/Watch.jpeg';
                    break;
                case 'headphones':
                    imagePath = 'Images/Headphones.jpg';
                    break;
                case 'pixel tablet':
                    imagePath = 'Images/Pixel Tablet.jpg';
                    break;
                case 'accessories':
                    imagePath = 'Images/Accessories.jpeg';
                    break;
                default:
                    imagePath = 'Images/defaultImage.jpeg'; 
                    break;
            }

            productBlock.innerHTML = `
                <div class="card">
                    <img src="${imagePath}" class="card-img-top" alt="${product.name}">
                    <div class="card-body d-flex flex-column justify-content-between">
                        <h5 class="card-title text-center mb-4">${product.name}</h5>
                        <p class="card-text mb-3">Price: ${product.price ? `$${product.price}` : 'Not available'}</p>
                        <p class="card-text mb-3">Memory: ${product.memory}</p>
                        <p class="card-text mb-3">Color: ${product.color}</p>
                        <p class="card-text mb-4">Category: ${product.categoryName}</p>
                        <button class="btn btn-outline-success addToBasketBtn" data-product-id="${product.id}" data-price="${product.price}">Buy now</button>
                    </div>
                </div>
            `;

            productContainer.appendChild(productBlock);
        });
    } catch (error) {
        console.error('An error occurred while downloading the products:', error);
    }

    const addToBasketButtons = document.querySelectorAll('.addToBasketBtn');

    addToBasketButtons.forEach(button => {
        button.addEventListener('click', async () => {
            const productId = button.getAttribute('data-product-id');
            const productName = button.parentElement.querySelector('.card-title').innerText;
            const productPrice = parseFloat(button.parentElement.querySelector('.card-text:nth-child(2)').textContent.replace('Price: $', ''));
            const memory = button.parentElement.querySelector('.card-text:nth-child(4)').textContent.replace('Memory: ', '');
            const color = button.parentElement.querySelector('.card-text:nth-child(3)').textContent.replace('Color: ', '');

            const quantity = prompt(`Enter the quantity for ${productName}:`, '1');

            if (quantity === null || isNaN(quantity) || quantity <= 0) {
                alert('Invalid quantity. Please enter a valid number greater than 0.');
                return;
            }

            let basket = JSON.parse(localStorage.getItem('basket')) || { items: [] };
            for (let i = 0; i < quantity; i++) {
                const product = {
                    id: productId,  
                    name: productName,
                    price: productPrice,  
                    color: color,
                    memory: memory,
                };
                basket.items.push(product);
            }

            localStorage.setItem('basket', JSON.stringify(basket));

            alert(`Added ${quantity} ${productName}(s) to the basket.`);
        });
    });
});