
    // Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
    // for details on configuring this project to bundle and minify static web assets.

    // Write your JavaScript code.
const main = async () => {
    var url = '/api/Customer';
    var reponse = await fetch(url);
    var data = await reponse.json();
    renderSlide(data);
}
const renderSlide = (data) => {
    var domSlide = document.querySelector("#bodyContent")
    var html = '';
    data.forEach((element, index) => {
        var birthdayString = moment(element.birthday).format('DD-MM-YYYY');
        var dateString = moment(element.date).format('DD-MM-YYYY');
        html += `
        <tr>
            <th scope="row">${element.id}</th>
            <td>${element.fullName}</td>
            <td>${birthdayString}</td>
            <td>${dateString}</td>
            <td>${element.phone}</td>
            <td>${element.address}</td>
            <td>${element.email}</td>

            <td>
                <button type="button" class="btn btn-warning" onclick='renderUpdate(${JSON.stringify(element)})'>
                        <i class="fa-solid fa-pen-to-square"></i>
                </button>
                <button type="button" class="btn btn-danger" onclick='Delete(${element.id})'>
                        <i class="fa-regular fa-trash"></i>
                </button>
            </td>
        </tr>
        `;
    });
    domSlide.innerHTML = html;
}

const renderUpdate = (data) => {
    let html = `
        <div class="modal" id="modalUpdate">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Edit TypeClothes</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <!-- Modal body -->

                    <div class="modal-body">
                        <div class="form-group">
                            <div class="mb-3 mt-3">
                                <label for="txtid" class="form-label">ID : </label>
                                <input type="text" class="form-control" value="${data.id}" id="txtid" name="txtid" readonly>

                                    <label for="txtname_update" class="form-label">Full Name : </label>
                                    <input type="text" class="form-control" id="txtname_update" value="${data.fullName}" placeholder="Enter Name" name="txtname_update" required>

                                        <label for="txtbirthday_update" class="form-label">Birthday : </label>
                                        <input type="date" class="form-control" id="txtbirthday_update" placeholder="Enter Birthday" name="txtbirthday_update">

                                            <label for="txtdate_update" class="form-label">Created Date  : </label>
                                            <input type="date" class="form-control" id="txtdate_update" placeholder="Enter Created Date" name="txtdate_update">



                                                <label for="txtphone_update" class="form-label">Phone : </label>
                                                <input type="text" class="form-control" id="txtphone_update" value="${data.phone}" placeholder="Enter Phone" name="txtphone_update">

                                                    <label for="txtaddress_update" class="form-label">Address : </label>
                                                    <input type="text" class="form-control" id="txtaddress_update" value="${data.address}" placeholder="Enter Address" name="txtaddress_update">

                                                        <label for="txtemail_update" class="form-label">Email : </label>
                                                        <input type="email" class="form-control" id="txtemail_update" value="${data.email}" placeholder="Enter Email" name="txtemail_update">


                                                        </div>

                                                        <td>
                                                            <button type="button" class="btn btn-primary" onclick="Update()">Submit</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>`;
    document.querySelector("#renderUpdate").innerHTML = html;
    var timerFormat = moment(data.birthday).format('YYYY-MM-DD');
    $('#txtbirthday_update').val(timerFormat);

    var timerFormat2 = moment(data.date).format('YYYY-MM-DD');
    $('#txtdate_update').val(timerFormat2);

    $('#modalUpdate').modal('show')
}
const Add = async () => {
    let fullName = document.querySelector("#txtname").value;
    let birthday = document.querySelector("#txtbirthday").value;
    let phone = document.querySelector("#txtphone").value;
    let address = document.querySelector("#txtaddress").value;
    let email = document.querySelector("#txtemail").value;
    var birth = new Date(birthday).toJSON();
    var d = new Date();
    var date = d.toJSON();

    let dataSend = {
        fullName: fullName,
        birthday: birth,
        date: date,
        phone: phone,
        address: address,
        email: email
    };
    let response = await fetch("/api/Customer", {
        method: "POST",
        body: JSON.stringify(dataSend),
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    }).then(rs => {
        if (rs.status == 200) {
            alert("Thêm thành công!!!");
            main()
        } else {
            console.log(rs);
            console.log(rs.body);
            console.log(rs.json()['message']);
            alert("Thêm thất bại");
        }
    })
}
const Delete = async (id) => {
    let response = await fetch("/api/Customer?id=" + id, {
        method: "DELETE",
    }).then(rs => {
        if (rs.status == 200) {
            alert("Xóa thành công!!!");
            main()
        } else {
            alert("Xóa thất bại")
        }
    })
}
const Update = async () => {
    let id = document.querySelector("#txtid").value;
    let fullName = document.querySelector("#txtname_update").value;
    let birthday = document.querySelector("#txtbirthday_update").value;
    let date = document.querySelector("#txtdate_update").value;
    let phone = document.querySelector("#txtphone_update").value;
    let address = document.querySelector("#txtaddress_update").value;
    let email = document.querySelector("#txtemail_update").value;
    var birth = new Date(birthday).toJSON();
    var d = new Date(date).toJSON();
    let dataSend = {
        fullName: fullName,
        birthday: birth,
        date: d,
        phone: phone,
        address: address,
        email: email
    };
    let response = await fetch("/api/Customer?id=" + id, {
        method: "PUT",
        body: JSON.stringify(dataSend),
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    }).then(rs => {
        if (rs.status == 200) {
            alert("Chỉnh sửa thành công!!!");
            main()
        } else {
            alert("Chỉnh sửa thất bại")
        }
    })
}
main()
