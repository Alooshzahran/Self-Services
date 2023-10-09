let shift = document.querySelector('#DateFrom');
shift.addEventListener('Change', function () {
    var theShift = shift.value;
    GetShift(theShift);
})
function GetShift(shift) {
    let request = new XMLHttpRequest();
    request.open('Get', 'https://localhost:7191/api/EmployeeShift/' + shift);

    request.send();
    request.addEventListener('load', function () {
        let [data] = JSON.parse(request.responseText)
        console.log(data);
        const html = '<tr> <th style = "text-align:center" >' + data.EmployeeID + '</th><th style="text-align:center">' + data.ShiftTypeID + '</th></tr > ';
        let table = document.querySelector('#shifttable');
        table.insertAdjacentHTML('beforeend', html);
    })
}