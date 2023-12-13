async function openOrderModal() {
    const orderModal = $('#orderModal');
    orderModal.find('.modal-body').empty();
    orderModal.find('.modal-body').append('<p>Order details go here...</p>');
    orderModal.modal('show');
}

function openEditModal(userId) {
    const user = getUserById(userId);
    fillEditModal(user);

    const modal = $('#editUserModal');
    modal.data('userId', userId);

    const deleteBtn = document.querySelector('#editUserModal .btn-outline-danger');
    deleteBtn.addEventListener('click', function () {
        deleteUser(userId);
    });

    const ordersBtn = document.querySelector('#editUserModal .btn-outline-secondary');
    ordersBtn.addEventListener('click', function () {
        openUserOrdersModal(userId);
    });

    const saveChangesBtn = document.getElementById('saveChangesBtn');
    saveChangesBtn.addEventListener('click', saveChanges);

    modal.modal('show');
}

async function openUserOrdersModal(userId) {
    try {
        const response = await fetch(`https://localhost:7291/Admin/User/Order?userId=${userId}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('token'),
            },
        });

        if (response.ok) {
            const userOrders = await response.json();
            console.log('User orders:', userOrders);

            displayUserOrdersModal(userOrders);
        } else {
            const errorData = await response.json();
            console.error('Error when receiving user orders:', errorData);
        }
    } catch (error) {
        console.error('An error has occurred:', error);

        if (error instanceof TypeError && error.message.includes('Failed to fetch')) {
            console.error('Network connection error. Please check the availability of the server.');
        }
    }
}

function displayUserOrdersModal(userOrders) {
    const orderModal = $('#orderModal');
    const modalBody = orderModal.find('.modal-body');
    modalBody.empty();

    userOrders.forEach(order => {
        modalBody.append('<hr>');

        let tr = `<table class="table table-bordered">
            <tr><th>ID</th><td>${order.orderId}</td></tr>
            <tr><th>CreatedAt</th><td>${order.createdAt}</td></tr>
            <tr><th>Status</th><td>${order.status}</td></tr>
            <tr><th>Product</th><td>${order.listProductName}</td></tr>
            <tr><th>Memory</th><td>${order.listProductMemory}</td></tr>
            <tr><th>Color</th><td>${order.listProductColor}</td></tr>
            <tr><th>Payment</th><td>${order.typePayment}</td></tr>
            <tr><th>Delivery</th><td>${order.typeDelivery}</td></tr>
            <tr><th>Total Price</th><td>${order.totalPrice}$</td></tr>
            <tr><th></th><td>
                <button class="btn btn-outline-success btn-sm" onclick="openEditOrderModal('${order.orderId}')">Edit</button>
            </td></tr>
        </table>`;
        modalBody.append(tr);
    });

    orderModal.modal('show');
}

function openEditOrderModal(orderData) {
    const editOrderModal = $('#editOrderModal');
    const modalBody = editOrderModal.find('.modal-body');

    modalBody.empty();

    const orderDetailsForm = `
        <form id="editOrderForm">
            <div class="modal-body">
            <input type="hidden" id="editOrderId">
            <div class="row">
                <div class="col-md-6">
                    <label for="editProducts">Products</label>
                    <select class="form-select selectpicker mb-3" data-live-search="true" id="editProducts" title="Select Products" multiple></select>
                </div>
                <div class="col-md-6">
                    <label for="editPaymentId" class="mb-3">Payment</label>
                    <select class="form-control mb-3" id="editPaymentId">
                        <option value="7">Сash</option>
                        <option value="5">Сard</option>
                        <option value="6">E-money</option>
                    </select>
                </div>
            </div>
            <div class="col-md-6">
                <label for="editDelivery">Delivery</label>
                <select class="form-control mb-3" id="editDelivery"> 
                    <option value="3">Pickup</option>
                    <option value="4">Courier</option>
                    <option value="2">Mail</option>
                </select>
            </div>
                <div class="col-md-6">
                <label for="editQuantity">Quantity</label>
                <input type="number" class="form-control mb-3" id="editQuantity" required min="1" max="10">
            </div>
        </div>
        </form>
    `;

    modalBody.append(orderDetailsForm);

    editOrderModal.modal('show');
}

async function deleteOrderItem(orderId, productId) {
    try {
        const response = await fetch(`https://localhost:7291/Admin/User/Order/DeleteItem?orderId=${orderId}&productId=${productId}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('token'),
            },
        });

        if (response.ok) {
            console.log('Order item deleted successfully');
        } else {
            const errorData = await response.json();
            console.error('Error when deleting order item:', errorData);
        }
    } catch (error) {
        console.error('An error has occurred:', error);
    }
}