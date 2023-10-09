function Delete(Url, id) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })

    swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
          
            $.ajax({
                url: Url,
                type: 'DELETE',
                data: {
                    ID: id
                },
                success: function (result) {
                    if (result.result != null) {
                        debugger;
                        if (result.id == -99) {
                            swalWithBootstrapButtons.fire(
                                'Deleted!',
                                'Your Data Cannot be delete.',
                                'error'
                            )
                        } else {
                            swalWithBootstrapButtons.fire(
                                'Deleted!',
                                'Your Data has been deleted.',
                                'success'
                            )
                            $('#tr_' + id).remove();
                            $('tbody > tr:first > td > input[type=checkbox]').prop("checked", true);
                        }
                    } else {
                        swalWithBootstrapButtons.fire(
                            'Deleted!',
                            'Your Data has been deleted.',
                            'success'
                        )
                        $('#tr_' + id).remove();
                        $('tbody > tr:first > td > input[type=checkbox]').prop("checked", true);
                    }

                },

                error: function (result) {
                    swalWithBootstrapButtons.fire(
                        'Deleted!',
                        'Your Data Cannot be delete.',
                        'error'
                    )
                }
            });

        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your Data is safe :)',
                'error'
            )
        }
    })
}
