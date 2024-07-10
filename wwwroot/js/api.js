//const uri = window.location.href;
//var uri = '@($"{Context.Request.Scheme}://{Context.Request.Host.Value}{Url.Content("~/")}")Register';
const uri = "Register";

function addItem() {
    //$('#submitBTN').on('click', function () {

    const FirstNameTextbox = document.querySelector("[name='FirstName']");
    const LastNameTextbox = document.querySelector("[name='LastName']");
    const UsernameTextbox = document.querySelector("[name='Username']");
    const PasswordTextbox = document.querySelector("[name='Password']");


    const item = {
        FirstName: FirstNameTextbox.value.trim(),
        LastName: LastNameTextbox.value.trim(),
        Username: UsernameTextbox.value.trim(),
        Password: PasswordTextbox.value.trim(),
    };
    console.log(item);
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            //getItems();
            //console.log(response)
            FirstNameTextbox.value = '';
            LastNameTextbox.value = '';
            UsernameTextbox.value = '';
            PasswordTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}