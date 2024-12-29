var ingredients = [];
var recipeDetails = [];

const urlParams = new URLSearchParams(window.location.search);
const ProductID = urlParams.get('ProductID');

function load() {
    console.log(recipeDetails);
    $.ajax({
        type: "POST",
        url: "edit.aspx/GetIngredients",
        data: JSON.stringify({}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var ingredients = response.d;
            renderIngredint(ingredients);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });

    $.ajax({
        type: "POST",
        url: "edit.aspx/GetRecipeDetails",
        data: JSON.stringify({ ProductID: ProductID }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            recipeDetails = response.d;
            renderRow(recipeDetails);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}

function renderIngredint(ingredients) {
    var load_ingredint = document.getElementById("load_ingredint");
    load_ingredint.innerHTML = "";

    ingredients.forEach(item => {
        var row = document.createElement('tr');
        row.innerHTML = `
            <td class="ingredint">
                <div class="ingredint_item">
                    <h2>${item.Name}</h2>
                </div>
                <input type="button" value="+" onclick="renderDetail(${item.IngredientID}, '${item.Name}', '${item.UnitName}')">
            </td>
        `;
        load_ingredint.appendChild(row);
    });
}

function renderDetail(id, Name, UnitName) {
    const ingredient = recipeDetails.find(item => item.IngredientID === id);

    if (ingredient) {
        ingredient.QuantityNeed += 1;
    } else {
        const newIngredient = {
            IngredientID: id,
            Name: Name,
            QuantityNeed: 1,
            UnitName: UnitName,
            ProductID: ProductID,
        };
        recipeDetails.push(newIngredient);
    }
    renderRow(recipeDetails);
}

function renderRow(recipeDetails) {
    console.log(recipeDetails);

    var tbody = document.getElementById('E_imports_load');
    tbody.innerHTML = '';

    recipeDetails.forEach(ingredient => {
        var row = document.createElement('tr');
        row.innerHTML = `
            <td>${ingredient.Name}</td>
            <td><input type="number" min="1" value="${ingredient.QuantityNeed}" onchange="updateQuantity(${ingredient.IngredientID}, this.value)" 
                    onkeydown="handleKeyDown(event, ${ingredient.IngredientID})"></td>
            <td>${ingredient.UnitName}</td>
            <td>
                <input type="button" onclick="deleteIngredient(${ingredient.IngredientID})" value="Xóa">
            </td>
        `;
        tbody.appendChild(row);
    });
}

function handleKeyDown(event, ingredientID) {
    if (event.key === "Enter") {
        event.preventDefault();

        const newQuantity = event.target.value;

        updateQuantity(ingredientID, newQuantity);
    }
}

function updateQuantity(ingredientID, newQuantity) {
    const ingredient = recipeDetails.find(item => item.IngredientID === ingredientID);
    if (ingredient) {
        ingredient.QuantityNeed = parseInt(newQuantity, 10);
    }
}

function deleteIngredient(ingredientID) {
    const index = recipeDetails.findIndex(item => item.IngredientID === ingredientID);
    if (index !== -1) {
        recipeDetails.splice(index, 1);
    }
    renderRow(recipeDetails);
}

function btnLuu() {
    $.ajax({
        type: "POST",
        url: "edit.aspx/Add",
        data: JSON.stringify({ recipeDetails: recipeDetails }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d === true) {
                Swal.fire({
                    title: 'Thông báo!',
                    text: 'Lưu công thức thành công',
                    icon: 'success'
                }).then(() => {
                    window.location.href = './';
                });
            }

        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
}

load();

var exit = document.querySelector('.exit');
if (exit) {
    exit.onclick = function () {
        window.location.href = './';
    }
}
