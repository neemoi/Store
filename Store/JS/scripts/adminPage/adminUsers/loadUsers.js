let users;

async function loadUsers() {
    try {
        const responseUsers = await fetch('https://localhost:7291/Admin/User', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('token'),
            },
        });

        if (responseUsers.ok) {
            users = await responseUsers.json();
            console.log('Users:', users);

            displayUsers(users);
        } else {
            const errorData = await responseUsers.json();
            console.error('Error when fetching users:', errorData);
        }
    } catch (error) {
        console.error('An error has occurred:', error);

        if (error instanceof TypeError && error.message.includes('Failed to fetch')) {
            console.error('Network connection error. Please check server availability.');
        }
    }
}
