document.addEventListener("DOMContentLoaded", async () => {
    let products;

    try {
        const token = localStorage.getItem('token');

        if (!token) {
            console.error('The token was not found. The user is not authenticated.');
            return;
        }

        const response = await fetch('https://localhost:7291/User/Order/Product');

        if (response.ok) {
            const data = await response.json();
            console.log(data);

            products = data.map(product => ({
                id: product.id,
                name: product.name,
                description: product.description,
                price: product.price,
                color: product.color,
                memory: product.memory,
            }));
            displayProductOptions(products);
        } else {
            console.error('Error when receiving product data:', response);
        }
    } catch (error) {
        console.error('An error has occurred:', error);
    }

    function displayProductOptions(products) {
        const selectProducts = document.getElementById('editProducts');

        products.forEach(product => {
            const option = document.createElement('option');
            option.value = product.name;
            option.setAttribute('data-id', product.id);
            option.text = `${product.name} Memory: ${product.memory} Color: ${product.color} Price: ${product.price}$`;
            selectProducts.appendChild(option);
        });

        $('.selectpicker').selectpicker('refresh');
    }

    const saveEditOrderButton = document.getElementById('saveEditOrder');
    saveEditOrderButton.addEventListener('click', async () => {
        try {
            const token = localStorage.getItem('token');

            if (!token) {
                console.error('The token was not found. The user is not authenticated.');
                return;
            }
            
            const orderId = document.getElementById('editOrderId').value;
            const listProductNames = $('#editProducts').val();
            const listProductIds = listProductNames.map(name => {
                const selectedProduct = products.find(product => product.name === name);
                return selectedProduct ? selectedProduct.id : null;
            });
            const paymentId = $('#editPaymentId').val();
            const deliverId = $('#editDelivery').val();
            const quantity = document.getElementById('editQuantity').value;

            if (quantity.trim() === '') {
                showError('Quantity is required.');
                return;
            }

            const quantityValue = parseInt(quantity);
            if (quantityValue < 1 || quantityValue > 15) {
                showError('Quantity must be between 1 and 15');
                return;
            }

            const orderData = {
                orderId: orderId,
                listProductId: listProductIds,
                paymentId: paymentId,
                deliverId: deliverId,
                quantity: quantity
            };

            const response = await fetch('https://localhost:7291/User/Order', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`,
                },
                body: JSON.stringify(orderData)
            });

            if (response.ok) {
                const result = await response.json();
                console.log('Order successfully edited:', result);

                location.reload();
                $('#editOrderModal').modal('hide');
            } else {
                const errorData = await response.json();
                console.error('Error editing order:', errorData);
            }
        } catch (error) {
            console.error('An error has occurred:', error);
        }

        function showError(message) {
            alert(message);
        }
    });

    const deleteProductBtn = document.getElementById('deleteProductBtn');
        deleteProductBtn.addEventListener('click', async function () {
            const confirmed = confirm('Are you sure you want to delete this order?');

            if (confirmed) {
                try {
                    const token = localStorage.getItem('token');

                    if (!token) {
                        console.error('The token was not found. The user is not authenticated.');
                        return;
                    }

                    const orderId = document.getElementById('editOrderId').value;

                    const response = await fetch(`https://localhost:7291/User/Order/${orderId}`, {
                        method: 'DELETE',
                        headers: {
                            'Content-Type': 'application/json',
                            'Authorization': `Bearer ${token}`,
                        },
                    });

                    if (response.ok) {
                        const result = await response.json();
                        console.log('Order successfully edited:', result);
                    
                        location.reload();
                        $('#editOrderModal').modal('hide');
                    } else {
                        const errorData = await response.json();
                        console.error('Error editing order:', errorData);
                    }
                } catch (error) {
                    console.error('An error has occurred:', error);
                }
            } else {
                console.log('Deletion canceled');
            }
        });

        if (logoutTab) {
            logoutTab.addEventListener('click', () => {
                localStorage.removeItem('token');
    
                location.reload();
            });
        }
});

