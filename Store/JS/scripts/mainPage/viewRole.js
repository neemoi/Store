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
        });
    }
});

function parseJwt(token) {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(c => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)).join(''));
    return JSON.parse(jsonPayload);
}