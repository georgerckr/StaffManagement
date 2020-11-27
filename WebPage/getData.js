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
        newRow.setAttribute("onClick", 'edit(' + i + ')');

        newRow.appendChild(document.createElement('td')); //Added for checkbox
        var checkbox = document.createElement("INPUT"); //Added for checkbox
        checkbox.id = "checkbox" + i;
        checkbox.type = "checkbox";
        newRow.cells[0].appendChild(checkbox);

        let cell1 = newRow.insertCell(1);
        let cell2 = newRow.insertCell(2);
        let cell3 = newRow.insertCell(3);
        let cell4 = newRow.insertCell(4);

        cell1.innerHTML = staffData[i]['staffId'];
        cell2.innerHTML = staffData[i]['fullName'];
        cell3.innerHTML = staffData[i]['dateJoined'];


        if (type == "admin") {
            let cell5 = newRow.insertCell(5);
            let cell6 = newRow.insertCell(6);
            cell4.innerHTML = 'Administrative Staff';
            cell5.innerHTML = staffData[i]['department'];
            cell6.innerHTML = staffData[i]['role'];

        }
        else if (type == "teaching") {
            let cell5 = newRow.insertCell(5);
            cell4.innerHTML = 'Teaching Staff';
            cell5.innerHTML = staffData[i]['subject'];

        }
        else {
            let cell5 = newRow.insertCell(5);
            cell4.innerHTML = 'Support Staff';
            cell5.innerHTML = staffData[i]['category'];

        }

    }
}

function getStaffByType() {
    let staffType = document.getElementById("Staff").value;
    let col;
    if (staffType == "admin") {
        col = `<tr>
 <th><input type="checkbox" onclick="checkAll(this)"></th>
		 <th>ID</th>
		 <th>Name</th>
		 <th>Date of Joining</th>
		 <th>Staff Type</th>
		 <th>Department</th>
		 <th>Role</th>
       
		 </tr>`;
        url = 'https://localhost:44377/api/Staff?type=admin';
    }
    else if (staffType == "teaching") {
        col = `<tr>
 <th><input type="checkbox" onclick="checkAll(this)"></th>
		 <th>ID</th>
		 <th>Name</th>
		 <th>Date of Joining</th>
		 <th>Staff Type</th>
		 <th>Subject</th>
      
		 </tr>`;
        url = 'https://localhost:44377/api/Staff?type=teaching';
    }
    else {
        col = `<tr>
 <th><input type="checkbox" onclick="checkAll(this)"></th>
		 <th>ID</th>
		 <th>Name</th>
		 <th>Date of Joining</th>	
		 <th>Staff Type</th>
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

function checkAll(bx) {
    var cbs = document.getElementsByTagName('input');
    for (var i = 0; i < cbs.length; i++) {
        if (cbs[i].type == 'checkbox') {
            cbs[i].checked = bx.checked;
        }
    }
}