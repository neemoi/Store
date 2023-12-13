async function openEditModal(userId) {
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

async function openEditModal(userId) {
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

function getUserById(userId) {
    const foundUser = users.find(user => user.id === userId);
    return foundUser || null;
}

function fillEditModal(user) {
    document.getElementById('editUserName').value = user.userName;
    document.getElementById('editUserEmail').value = user.email;
    document.getElementById('editUserPhone').value = user.phoneNumber;
    document.getElementById('editUserState').value = user.state;
    document.getElementById('editUserCity').value = user.city;
    document.getElementById('editUserAddress').value = user.address;
}

function getUserIdFromModal() {
    const modal = $('#editUserModal');
    const userId = modal.data('userId'); 
    console.log('User ID:', userId);
    return userId;
}

async function saveChanges() {
    const userId = getUserIdFromModal();
    const updatedUserData = {
        id: userId,
        userName: document.getElementById('editUserName').value,
        email: document.getElementById('editUserEmail').value,
        phoneNumber: document.getElementById('editUserPhone').value,
        state: document.getElementById('editUserState').value,
        city: document.getElementById('editUserCity').value,
        address: document.getElementById('editUserAddress').value,
    };

    try {
        const response = await fetch(`https://localhost:7291/Admin/User/`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('token'),
            },
            body: JSON.stringify(updatedUserData),
        });

        if (response.ok) {
            const updatedUser = await response.json();
            console.log('User updated successfully:', updatedUser);

            $('#editUserModal').modal('hide');
        } else {
            const contentType = response.headers.get('content-type');
            if (contentType && contentType.includes('application/json')) {
                const errorData = await response.json();
                console.error('Error updating user:', errorData);
            } else {
                console.error('Error updating user. Response not in JSON format.');
            }
        }
    } catch (error) {
        console.error('An error has occurred:', error);
    }
}

async function deleteUser(userId) {
    const confirmation = confirm("Are you sure you want to delete this user?");
    if (!confirmation) {
        return;
    }

    try {
        const response = await fetch(`https://localhost:7291/Admin/User/${userId}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('token'),
            },
        });

        if (response.ok) {
            loadUsers();
            console.log('User deleted successfully');

            $('#editUserModal').modal('hide');
        } else {
            const errorData = await response.json();
            console.error('Error when deleting user:', errorData);
        }
    } catch (error) {
        console.error('An error has occurred:', error);
    }
}

async function openOrderModal() {
    const orderModal = $('#orderModal');
    orderModal.find('.modal-body').empty();
    orderModal.find('.modal-body').append('<p>Order details go here...</p>');
    orderModal.modal('show');
}

async function openEditModal(userId) {
    const user = getUserById(userId);
    fillEditModal(user);

    const modal = $('#editUserModal');
    modal.data('userId', userId);

    const deleteBtn = document.querySelector('#editUserModal .btn-outline-danger');
    deleteBtn.addEventListener('click', function () {
        deleteUser(userId);
    });

    const ordersBtn = document.querySelector('#editUserModal .btn-outline-secondary');
    ordersBtn.addEventListener('click', async function () {
        await openUserOrdersModal(userId);
    });

    const saveChangesBtn = document.getElementById('saveChangesBtn');
    saveChangesBtn.addEventListener('click', saveChanges);

    modal.modal('show');
}

async function openRoleModal() {
    $('#roleModal').modal('show');
}

async function saveRoleChanges() {
    const userId = getUserIdFromModal();
    const selectedRoleId = document.getElementById('roleSelect').value;
    console.info('userId:', userId);
    console.info('selectedRoleId:', selectedRoleId);
    
    try {
        const response = await fetch('https://localhost:7291/Admin/User/Role', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('token'),
            },
            body: JSON.stringify({
                userId: userId,
                roleId: selectedRoleId,
            }),
        });

        if (response.ok) {
            console.log('Role updated successfully');
            $('#roleModal').modal('hide');
        } else {
            const errorData = await response.json();
            console.error('Error updating role:', errorData);
        }
    } catch (error) {
        console.error('An error has occurred:', error);
    }
}
