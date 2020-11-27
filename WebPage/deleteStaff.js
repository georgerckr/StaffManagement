function DeleteStaffById(id) {
    var btn = document.createElement("BUTTON");
    btn.innerHTML = "CLICK ME";
    document.body.appendChild(btn);
}
fetch("https://localhost:44377/api/Staff" + id, {
    method: 'DELETE',

}).then(response => {
    response.json()
    getStaffByType();
})
    .then(json => console.log(json))
    .catch(error => console.error('Unable to add item.', error));