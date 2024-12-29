const urlParams = new URLSearchParams(window.location.search);
const ProductID = urlParams.get('ProductID');
function load() {
    var recipes = [];

    $.ajax({
        type: "POST",
        url: "index.aspx/GetRecipeByProductID",
        data: JSON.stringify({ ProductID: ProductID }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            recipes = response.d;
            renderTable(recipes);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}

function renderTable(recipes) {
    const tableBody = document.getElementById('E_recipes_load');
    tableBody.innerHTML = ""; // Xóa nội dung cũ
    recipes.forEach(recipe_item => {
        const row = document.createElement('tr');
        row.innerHTML = `
           <td>${recipe_item.Name}</td>
            <td>${recipe_item.QuantityNeed}</td>
            <td>${recipe_item.UnitName}</td>
           `;
        tableBody.appendChild(row);
    });
}

load();

var exit = document.querySelector('.exit')
exit.onclick = function () {
    window.location.href = '../'
}
