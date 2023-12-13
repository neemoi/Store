document.addEventListener("DOMContentLoaded", () => {
    const token = localStorage.getItem('token');

    if (!token) {
        console.error('The token was not found. The user is not authenticated.');
        return;
    }

    const editProfileBtn = document.getElementById('editProfileBtn');
    const editProfileModal = new bootstrap.Modal(document.getElementById('editProfileModal'));

    editProfileBtn.addEventListener('click', () => {
        editProfileModal.show();
    });

    const saveChangesBtn = document.getElementById('saveChangesBtn');
    saveChangesBtn.addEventListener('click', async () => {
        const editProfileForm = document.getElementById('editProfileForm');
        const currentPassword = document.getElementById('editCurrentPassword').value;
        const newPassword = document.getElementById('editNewPassword').value;

        if (!currentPassword || !newPassword) {
            alert('Both current and new passwords are required.');
            return;
        }

        const formData = {
            userName: document.getElementById('editUserName').value,
            email: document.getElementById('editEmail').value,
            currentPassword,
            newPassword,
            phoneNumber: document.getElementById('editPhoneNumber').value,
            state: document.getElementById('editState').value,
            city: document.getElementById('editCity').value,
            address: document.getElementById('editAddress').value
        };

        try {
            const response = await fetch('https://localhost:7291/User/Profile', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`,
                },  
                body: JSON.stringify(formData),
            });

            if (response.ok) {
                const updatedUserData = await response.json();
                console.log('The users profile has been updated:', updatedUserData);

                window.location.reload();
            } else {
                const errorText = await response.text();
                console.error('Error updating user profile:', errorText);
            }

            editProfileModal.hide();
        } catch (error) {
            console.error('An error has occurred:', error);
        }
    });

    if (logoutTab) {
        logoutTab.addEventListener('click', () => {
            localStorage.removeItem('token');

            location.reload();
        });
    }
});

document.addEventListener("DOMContentLoaded", async () => {
    try {
        const token = localStorage.getItem('token');

        if (!token) {
            console.error('The token was not found. The user is not authenticated.');
            return;
        }

        const response = await fetch('https://localhost:7291/User/Profile', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`,
            },
        });

        if (response.ok) {
            const userData = await response.json();
            console.log('User Data:', userData);

            document.getElementById('userName').value = userData.userName;
            document.getElementById('email').value = userData.email;
            document.getElementById('phoneNumber').value = userData.phoneNumber;
            document.getElementById('state').value = userData.state;
            document.getElementById('city').value = userData.city;
            document.getElementById('address').value = userData.address;

            document.getElementById('editUserName').value = userData.userName;
            document.getElementById('editEmail').value = userData.email;
            document.getElementById('editPhoneNumber').value = userData.phoneNumber;
            document.getElementById('editState').value = userData.state;
            document.getElementById('editCity').value = userData.city;
            document.getElementById('editAddress').value = userData.address;
        } else {
            const errorData = await response.json();
            console.error('Error when receiving user data:', errorData);
        }
    } catch (error) {
        console.error('An error has occurred:', error);
    }
});