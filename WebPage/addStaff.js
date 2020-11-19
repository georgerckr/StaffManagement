
let staffType;
function AddStaff() {
    staffType = document.getElementById("Staff").value;
    var form = "<br>Name: <input type='text' id=fullName><br>Date Joined: <input type='datetime-local'  id=dateJoined><br>";
    if (staffType == "admin") {
        form += "Department: <input type='text' id=department><br>Role: <input type='text' id=role><br>";
    }
    if (staffType == "teaching") {
        form += "Subject: <input type='text' id=subject><br>";
    }
    else {
        form += "Category: <input type='text' id=category><br>";
    }
    form += "<input type='button' value='Submit' onClick='submitData()'><br>";
    document.getElementById("addForm").innerHTML = form;
}


async function submitData() {
    let bodyData;
    if (staffType == "admin") {
        bodyData = JSON.stringify({
            fullName: document.getElementById("fullName").value,
            dateJoined: Date.parse(document.getElementById("dateJoined").value),
            role: document.getElementById("role").value,
            department: document.getElementById("department").value,
            staffType: 2
        });
    }
    else if (staffType == "teaching") {
        bodyData = JSON.stringify({
            fullName: document.getElementById("fullName").value,
            dateJoined: document.getElementById("dateJoined").value,
            subject: document.getElementById("subject").value,
            staffType: 1
        });
    }
    else if (staffType == "support") {
        bodyData = JSON.stringify({
            fullName: document.getElementById("fullName").value,
            dateJoined: document.getElementById("dateJoined").value,
            category: document.getElementById("category").value,
            staffType: 3
        });
    }
    console.log(bodyData);
    fetch("https://localhost:44377/api/Staff", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: bodyData
    }).then(response => {
        response.json()
        getStaffByType();
    })
        .then(json => console.log(json))
        .catch(error => console.error('Unable to add item.', error));
}

