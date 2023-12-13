document.addEventListener("DOMContentLoaded", async () => {
    try {
        const token = localStorage.getItem('token');

        if (!token) {
            console.error('The token was not found. The user is not authenticated.');
            return;
        }

        const response = await fetch('https://localhost:7291/User/Order', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`,
            },
        });

        if (response.ok) {
            const userData = await response.json();
            displayUserData(userData);
        } else {
            const errorData = await response.json();
            console.error('Error when receiving data about users orders', errorData);
        }
    } catch (error) {
        console.error('An error has occurred:', error);
    }
});

function displayUserData(userData) {
    const userDataContainer = document.getElementById('userDataContainer');

    if (!userData || userData.length === 0) {
        userDataContainer.innerHTML = '<p>There is no information about orders</p>';
        return;
    }

    const tableHtml = `
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Created</th>
                    <th scope="col">Status</th>
                    <th scope="col">Name</th>
                    <th scope="col">Price</th>
                    <th scope="col">Total Price</th>
                    <th scope="col">Color</th>
                    <th scope="col">Payment</th>
                    <th scope="col">Delivery</th>
                    <th scope="col">Actions</th>
                </tr>
            </thead>
            <tbody>
                ${userData.map(order => `
                    <tr>
                        <td>${order.createdAt}</td>
                        <td>${order.status}</td>
                        <td>${order.listProductName.join(', ')}</td>
                        <td>${order.listProductPrices.join(', ')}$</td>
                        <td>${order.totalPrice}$</td>
                        <td>${order.listProductColor.join(', ')}</td>
                        <td>${order.typePayment}</td>
                        <td>${order.typeDelivery}</td>
                        <td>
                            <button class="btn btn-outline-primary" data-toggle="modal" data-target="#editOrderModal" data-id="${order.orderId}">Edit</button>
                        </td>
                    </tr>
                `).join('')}
            </tbody>
        </table>
    `;

    userDataContainer.innerHTML = tableHtml;
    
    const editButtons = document.querySelectorAll('.edit-btn');
        editButtons.forEach(button => {
            button.addEventListener('click', function() {
                const orderId = this.getAttribute('data-id');
                console.log('Order id:', orderId);

                document.getElementById('editOrderId').value = orderId;
            });
        });
}