async function displayUsers(users) {
    if ($.fn.DataTable.isDataTable('#usersTable')) {
        $('#usersTable').DataTable().destroy();
    }

    const table = $('#usersTable').DataTable({
        data: users,
        columns: [
            { data: 'userName' },
            { data: 'email' },
            { data: 'phoneNumber' },
            { data: 'address' },
            { data: 'city' },
            { data: 'state' },
            {
                data: null,
                render: function (data, type, row) {
                    return `<button class="btn btn-outline-primary" onclick="openEditModal('${row.id}')">Edit</button>`;
                }
            }
        ],
        paging: true,
        pageLength: 8,
    });
}
