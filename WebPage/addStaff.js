
let staffType;
function AddStaff() {
    staffType = document.getElementById("Staff").value;
    var form = " <span class=\"close\" onClick=\" closeModal()\" >&times;</span> <br>Name <br><input type='text' id=fullName><br>Date Joined<br> <input type='datetime-local'  id=dateJoined><br>";
    //var form = " <br>Name <br><input type='text' id=fullName><br>Date Joined<br> <input type='datetime-local'  id=dateJoined><br>";
    if (staffType == "admin") {
        form += "Department<br> <input type='text' id=department><br>Role<br> <input type='text' id=role><br>";
    }
    if (staffType == "teaching") {
        form += "Subject<br> <input type='text' id=subject><br>";
    }
    if (staffType == "support") {
        form += "Category <br> <input type='text' id=category><br>";
    }
    form += "<input type='button' id='submitButton' value='Save' onClick='submitData()'><br>";
    
    document.getElementById("addForm").innerHTML = form;
   document.getElementById("addFormModal").style.display = "block";
}


async function submitData() {
    let bodyData;
    if (staffType == "admin") {
        bodyData = JSON.stringify({
            fullName: document.getElementById("fullName").value,
            dateJoined: document.getElementById("dateJoined").value,
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
        response.json();
        getStaffByType();
    })
        .then(json => console.log(json))
        .catch(error => console.error('Unable to add item.', error));
}
window.onclick = function (event) {
    if (event.target == document.getElementById("addFormModal")) {
        document.getElementById("addFormModal").style.display = "none";
    }
}

function closeModal() {
    document.getElementById("addFormModal").style.display = "none";
}
