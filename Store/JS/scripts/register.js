document.addEventListener("DOMContentLoaded", () => {
    const registrationForm = document.getElementById("registrationForm");

    registrationForm.addEventListener("submit", async (event) => {
        event.preventDefault();

        const email = document.getElementById("email").value;
        const username = document.getElementById("username").value;
        const phoneNumber = document.getElementById("phonenumber").value;
        const password = document.getElementById("password").value;

        const formData = {
            Email: email,
            Name: username,
            PhoneNumber: phoneNumber,
            Password: password
        };

        try {
            const response = await fetch('https://localhost:7291/Register', {
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

                window.location.href = "main.html";
            } else {
                const errorData = await response.json();
                console.error('Error during registration:', errorData);

                alert('Invalid credentials. Please try again.');
            }
        } catch (error) {
            console.error('An error has occurred:', error);
        }
    });
});
