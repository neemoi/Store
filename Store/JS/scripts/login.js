document.addEventListener("DOMContentLoaded", () => {
    const loginForm = document.getElementById("loginForm");

    loginForm.addEventListener("submit", async (event) => {
        event.preventDefault();

        const username = document.getElementById("username").value;
        const password = document.getElementById("password").value;

        const formData = {
            UserName: username,
            Password: password
        };

        try {
            const response = await fetch('https://localhost:7291/Login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            });

            if (response.ok) {
                const tokenData = await response.json();
                const token = tokenData.token;

                localStorage.setItem('token', token);
                document.cookie = `token=${token}; path=/`;
 
                window.location.href = 'main.html';
            } else {
                const errorData = await response.json();
                console.error('Error during login:', errorData);

                alert('Invalid credentials. Please try again.');
            }
        } catch (error) {
            console.error('An error has occurred:', error);
        }
    });
});
