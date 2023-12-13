async function loadUserProfile() {
    try {
        const token = localStorage.getItem('token');

        if (!token) {
            console.error('The token was not found. The user is not authenticated.');
            return;
        }

        const responseProfile = await fetch('https://localhost:7291/User/Profile', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`,
            },
        });

        if (responseProfile.ok) {
            const userData = await responseProfile.json();
            console.log('User Data:', userData);

            document.getElementById('userState').value = userData.state;
            document.getElementById('userCity').value = userData.city;
            document.getElementById('userAddress').value = userData.address;
            document.getElementById('userPhoneNumber').value = userData.phoneNumber;
            document.getElementById('userName').value = userData.userName;
            document.getElementById('userEmail').value = userData.email;
        } else {
            const errorData = await responseProfile.json();
            console.error('Error when receiving user data:', errorData);
        }
    } catch (error) {
        console.error('An error has occurred:', error);
    }
}

document.addEventListener("DOMContentLoaded", loadUserProfile);
