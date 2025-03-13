$(document).ready(function () {


    $(".delete-course").click(function (e) {
        e.preventDefault();

        let courseId = $(this).data("id");

        Swal.fire({
            title: "Are you sure?",
            text: "Are you sure you want to delete the course?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Course/Delete/${courseId}`,
                    type: "POST",
                    success: function () {
                        Swal.fire(
                            "Deleted!",
                            "The course has been deleted.",
                            "success"
                        ).then(() => {
                            location.reload();
                        });
                    },
                    error: function () {
                        Swal.fire(
                            "Error!",
                            "There was an error deleting the course.",
                            "error"
                        );
                    }
                });
            }
        });
    });
});
