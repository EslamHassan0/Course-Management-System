$(document).ready(function () {


    $(".unroll-student").click(function (e) {
        e.preventDefault();

        let EnrollmentId = $(this).data("id");

        Swal.fire({
            title: "Are you sure?",
            text: "Are you sure this student's Unenroll has been cancelled?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
            confirmButtonText: "Yes, Unenroll it!"
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Enrollment/Unenroll/${EnrollmentId}`,
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
