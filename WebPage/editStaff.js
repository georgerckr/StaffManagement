function edit(id) {
    AddStaff();
    //DeleteStaffById(staffDatas[id]['staffId'] );
    document.getElementById('submitButton').setAttribute("onClick", 'editStaff(' + staffDatas[id]['staffId'] + ')');
    document.getElementById("fullName").value = staffDatas[id]['fullName'];
    document.getElementById("dateJoined").value = staffDatas[id]['dateJoined'];
    if (staffType == "admin") {
        document.getElementById("department").value = staffDatas[id]['department'];
        document.getElementById("role").value = staffDatas[id]['role'];
    }
    if (staffType == "teaching") {
        document.getElementById("subject").value = staffDatas[id]['subject'];
    }
    if (staffType == "support") {
        document.getElementById("category").value = staffDatas[id]['category'];
    }


}

function editStaff(staffID) {
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
    fetch("https://localhost:44377/api/Staff/" + staffID, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: bodyData
    }).then(response => {
        response.json()
        getStaffByType();
    })
        .then(json => console.log(json))
        .catch(error => console.error('Unable to edit item.', error));
}