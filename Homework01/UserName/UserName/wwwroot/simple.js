let getAllBtn = document.getElementById("btn1");
let getByIdBtn = document.getElementById("btn2");
let addUsernameBtn = document.getElementById("btn3");
let deleteBtn = document.getElementById("deleteBtn");
let getAllTagsBtn = document.getElementById("btn4");
let getTagByIdBtn = document.getElementById("btn5");
let getByIdInput = document.getElementById("input2");
let addUsernameInput = document.getElementById("input3");
let deleteInput = document.getElementById("delete");

let port = "61821";
let getAllUsernames = async () => {
    let url = "http://localhost:" + port + "/api/user";

    let response = await fetch(url);
    console.log(response);
    let data = await response.json();
    console.log(data);
};

let getUsernameById = async () => {
    let url = "http://localhost:" + port + "/api/user/" + getByIdInput.value;

    let response = await fetch(url);
    let data = await response.text();
    console.log(data);
};


let addUsername = async () => {
    let url = "http://localhost:" + port + "/api/user";
    var response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'text/plain'
        },
        body: addUsernameInput.value
    });
    var data = await response.text();
    console.log(data);
}

let deleteUsername = async () => {
    let url = "http://localhost:" + port + "/api/user";
    var response = await fetch(url, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'text/plain'
        },
        body: deleteInput.value
    });
    var data = await response.text();
    console.log(data);
    console.log(response);
}

getAllBtn.addEventListener("click", getAllUsernames);
getByIdBtn.addEventListener("click", getUsernameById);
addUsernameBtn.addEventListener("click", addUsername);

deleteBtn.addEventListener("click", deleteUsername);