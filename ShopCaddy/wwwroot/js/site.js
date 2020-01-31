// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.querySelectorAll(".received-Button").forEach(editButton => {
    editButton.addEventListener("click", function () {
        const editedPOFinal = {
            Received: true
        }
        console.log("You've clicked the received button")
        fetch(`/PurchaseOrders/Edit/${event.target.id}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(editedPOFinal)
        }).then(() => {window.location.reload(true)})

    })
})
