let url;
let staffDatas;
async function getStaffData(url) {
    let response = await fetch(url, {
        method: 'GET',
        mode: 'cors'
    });
    return response.json();

}

function insertValues(staffData, type) {
    for (let i = 0; i < staffData.length; i++) {
        let tableRef = document.getElementById("staffTable");
        let newRow = tableRef.insertRow();
        newRow.setAttribute("onClick", 'edit(' + i +')');
   
        let cell0 = newRow.insertCell(0);
        let cell1 = newRow.insertCell(1);
        let cell2 = newRow.insertCell(2);
        let cell3 = newRow.insertCell(3);
        let cell4 = newRow.insertCell(4);
        let cell5 = newRow.insertCell(5);
        cell0.innerHTML = staffData[i]['staffId'];
        cell1.innerHTML = staffData[i]['fullName'];
        cell2.innerHTML = staffData[i]['dateJoined'];

        if (type == "admin") {
            cell3.innerHTML = 'Administrative Staff';
            cell4.innerHTML = staffData[i]['department'];
            cell5.innerHTML = staffData[i]['role'];
        }
        else if (type == "teaching") {
            cell3.innerHTML = 'Teaching Staff';
            cell4.innerHTML = staffData[i]['subject'];
        }
        else {
            cell3.innerHTML = 'Support Staff';
            cell4.innerHTML = staffData[i]['category'];
        }
    }
}

function getStaffByType() {
    let staffType = document.getElementById("Staff").value;
    let col;
    if (staffType == "admin") {
        col = `<tr>
		 <th>ID</th>
		 <th>Name</th>
		 <th>Date of Joining</th>
		 <th>StaffType</th>
		 <th>Department</th>
		 <th>Role</th>
		 </tr>`;
        url = 'https://localhost:44377/api/Staff?type=admin';
    }
    else if (staffType == "teaching") {
        col = `<tr>
		 <th>ID</th>
		 <th>Name</th>
		 <th>Date of Joining</th>
		 <th>StaffType</th>
		 <th>Subject</th>
		 </tr>`;
        url = 'https://localhost:44377/api/Staff?type=teaching';
    }
    else {
        col = `<tr>
		 <th>ID</th>
		 <th>Name</th>
		 <th>Date of Joining</th>	
		 <th>StaffType</th>
		 <th>Category</th>
		 </tr>`;
        url = 'https://localhost:44377/api/Staff?type=support';
    }
    document.getElementById("staffTable").innerHTML = col;
    getStaffData(url)
        .then((data) => {
            console.log(data);
            insertValues(data, staffType);
            staffDatas = data;
        }).catch((error) => {
            console.log(error)
        });    
}
//function edit(id) {
//    AddStaff();
//    document.getElementById('submitButton').setAttribute("onClick", 'editStaff('+staffDatas[id]['staffId']+')');
//    document.getElementById("fullName").value = staffDatas[id]['fullName'];
//    document.getElementById("dateJoined").value = staffDatas[id]['dateJoined'];
//    if (staffType == "admin") {
//        document.getElementById("department").value = staffDatas[id]['department'];
//        document.getElementById("role").value = staffDatas[id]['role'];
//    }
//    if (staffType == "teaching") {
//        document.getElementById("subject").value = staffDatas[id]['subject'];
//    }
//    if (staffType == "support")  {
//        document.getElementById("category").value = staffDatas[id]['category'];
//    }
//}

//function editStaff(staffID) {
//    let bodyData;
//    if (staffType == "admin") {
//        bodyData = JSON.stringify({
//            fullName: document.getElementById("fullName").value,
//            dateJoined: document.getElementById("dateJoined").value,
//            role: document.getElementById("role").value,
//            department: document.getElementById("department").value,
//            staffType: 2
//        });
//    }
//    else if (staffType == "teaching") {
//        bodyData = JSON.stringify({
//            fullName: document.getElementById("fullName").value,
//            dateJoined: document.getElementById("dateJoined").value,
//            subject: document.getElementById("subject").value,
//            staffType: 1
//        });
//    }
//    else if (staffType == "support") {
//        bodyData = JSON.stringify({
//            fullName: document.getElementById("fullName").value,
//            dateJoined: document.getElementById("dateJoined").value,
//            category: document.getElementById("category").value,
//            staffType: 3
//        });
//    }
//    console.log(bodyData);
//    fetch("https://localhost:44377/api/Staff/" + staffID, {
//        method: 'PUT',
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: bodyData
//    }).then(response => {
//        response.json()
//        getStaffByType();
//    })
//        .then(json => console.log(json))
//        .catch(error => console.error('Unable to edit item.', error));
//}