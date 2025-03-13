$(document).ready(function () {

    
    $(".delete-student").click(function (e) {
        e.preventDefault();
       
        let studentId = $(this).data("id");

        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Student/Delete/${studentId}`,
                    type: "POST",
                    success: function () {
                        Swal.fire(
                            "Deleted!",
                            "The student has been deleted.",
                            "success"
                        ).then(() => {
                            location.reload();
                        });
                    },
                    error: function () {
                        Swal.fire(
                            "Error!",
                            "There was an error deleting the student.",
                            "error"
                        );
                    }
                });
            }
        });
    });
});
