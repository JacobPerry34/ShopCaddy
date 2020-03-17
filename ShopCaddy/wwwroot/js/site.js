// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//Received Button For the Purchase Order Index
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
        }).then(() => { window.location.reload(true) })

        //Another Fetch call to Edit the product quantity when the received button is clicked.

    })
})

//Delete Button for the Purchase Order Products on the Purchase Order Details Page
document.querySelectorAll(".delete-POP").forEach(deleteButton => {
    deleteButton.addEventListener("click", function () {
        console.log("You've clicked the delete button")
        fetch(`/PurchaseOrderProducts/Delete/${event.target.id}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }
           
        }).then(() => {window.location.reload(true)})
    })
})
