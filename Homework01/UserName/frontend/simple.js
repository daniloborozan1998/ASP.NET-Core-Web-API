let getAllBtn = document.getElementById("btn1");
let getByIdBtn = document.getElementById("btn2");
let getInfoBtn = document.getElementById("btnInfo");
let addUserBtn = document.getElementById("btn3");
let deleteBtn = document.getElementById("deleteBtn");
let getAllTagsBtn = document.getElementById("btn4");
let getTagByIdBtn = document.getElementById("btn5");
let getByIdInput = document.getElementById("input2");
let addUserInput = document.getElementById("input3");
let deleteInput = document.getElementById("delete");

let port = "61821";
let getAllUsersNames = async() => {
    let url = "http://localhost:" + port + "/api/user";

    let response = await fetch(url);
    console.log(response);
    let data = await response.json();
    console.log(data);
};

let getUserById = async() => {
    let url = "http://localhost:" + port + "/api/user/" + getByIdInput.value;

    let response = await fetch(url);
    let data = await response.text();
    console.log(data);
};

let getInfo = async() => {
    let url = "http://localhost:" + port + "/api/user/info";

    let response = await fetch(url);
    let data = await response.text();
    console.log(data);
};

let addUserName = async() => {
    let url = "http://localhost:" + port + "/api/user";
    var response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'text/plain'
        },
        body: addNoteInput.value
    });
    var data = await response.text();
    console.log(data);
}

let deleteUser = async() => {
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

getAllBtn.addEventListener("click", getAllUsersNames);
getByIdBtn.addEventListener("click", getUserById);
addUserBtn.addEventListener("click", addUserName);
getInfoBtn.addEventListener("click", getInfo);
deleteBtn.addEventListener("click", deleteUser);