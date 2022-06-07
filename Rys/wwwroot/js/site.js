$(document).ready(function () {
    ActiveNav();
});

function ActiveNav() {
    if (window.location.pathname.length > 1) {
        var navs = document.getElementsByClassName("menu-item");
        for (var i = 0; i < navs.length; i++) {
            navs[i].classList.remove("active");
        }
        var selecetedMenu = window.location.pathname.split("/")[1];
        document.getElementsByClassName("nav" + selecetedMenu)[0].classList.add("active");
    }

    else {
        document.getElementById("homenavlink").classList.add("active");
    }
}
const buttons = document.querySelectorAll(".btn-counter");
const minValue = 0;
const maxValue = 10;

buttons.forEach((button) => {
    button.addEventListener("click", (event) => {
        // 1. Get the clicked element
        const element = event.currentTarget;
        // 2. Get the parent
        const parent = element.parentNode;
        // 3. Get the number (within the parent)
        const numberContainer = parent.querySelector(".number-product");
        const number = parseFloat(numberContainer.textContent);
        // 4. Get the minus and plus buttons
        const increment = parent.querySelector(".plus");
        const decrement = parent.querySelector(".minus");
        // 5. Change the number based on click (either plus or minus)
        const newNumber = element.classList.contains("plus")
            ? number + 1
            : number - 1;

        numberContainer.textContent = newNumber;
        console.log(newNumber);

        // 6. Disable and enable buttons based on number value (and undim number)
        if (newNumber === minValue) {
            decrement.disabled = true;
            numberContainer.classList.add("dim");
            // Make sure the button won't get stuck in active state (Safari)
            element.blur();
        } else if (newNumber > minValue && newNumber < maxValue) {
            decrement.disabled = false;
            increment.disabled = false;
            numberContainer.classList.remove("dim");
        } else if (newNumber === maxValue) {
            increment.disabled = true;
            numberContainer.textContent = `${newNumber}+`;
            element.blur();
        }

        if (element.classList.contains("plus")) {
            alert("Ekle")
        } else {
            alert("Sil")
        }
    });
});