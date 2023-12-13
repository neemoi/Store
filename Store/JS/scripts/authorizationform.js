document.getElementById("loginForm").addEventListener("submit", function(event) {
    event.preventDefault(); 
    let username = document.getElementById("username").value;
    let password = document.getElementById("password").value;
    console.log("Logging in with username:", username, "and password:", password);
  });
  
  document.getElementById("registrationForm").addEventListener("submit", function(event) {
    event.preventDefault(); 
    let newUsername = document.getElementById("newUsername").value;
    let newPassword = document.getElementById("newPassword").value;
    console.log("Registering new user with username:", newUsername, "and password:", newPassword);
  });
  