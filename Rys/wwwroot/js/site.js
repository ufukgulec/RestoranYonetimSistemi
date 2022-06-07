

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
const sepetList = document.querySelector("body > div.layout-wrapper.layout-content-navbar > div.layout-container > div > div > div.container-xxl.flex-grow-1.container-p-y > div > div.col-md-4 > div > div.card-body > ul");
buttons.forEach((button) => {
    button.addEventListener("click", (event) => {
        // 1. Tıklanılan buton
        const element = event.currentTarget;
        // 2. Tıklanılan butonun bir üst kapsayıcısı
        const parent = element.parentNode;
        // 3. Adet yazan input (within the parent)
        const numberContainer = parent.querySelector(".number-product");
        const number = parseFloat(numberContainer.textContent);
        // 4.Artı eksi butonları
        const increment = parent.querySelector(".plus");
        const decrement = parent.querySelector(".minus");
        // 5. koşul
        const newNumber = element.classList.contains("plus")
            ? number + 1
            : number - 1;
        // 5.1. Yeni sayıyı atama
        numberContainer.textContent = newNumber;
        console.log(newNumber);
        // 5.2. Ürün ismi alma
        const areaparent = parent.parentNode;
        const productInfoArea = areaparent.querySelector(".title-product");
        const productName = productInfoArea.querySelector(".label-product").textContent;

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
            SepetEkle(newNumber, productName)
        } else {
            alert("Sil")
        }
    });
});

const products = new Array();

function SepetEkle(adet, ürünIsmı) {
    if (products.length > 0) {
        eklensin = true;

        products.forEach((product) => {
            if (product.name == ürünIsmı) {
                product.adet = +1;
                eklensin = false;
            }
        });
        if (eklensin) {
            products.push({ name: ürünIsmı, adet: adet });
            const satır = document.createElement("li");
            const badge = document.createElement("span");

            satır.className = "list-group-item d-flex justify-content-between align-items-center";
            satır.id = "item-" + ürünIsmı.split(" ");
            const ProductName = document.createTextNode(ürünIsmı);

            satır.appendChild(ProductName);
            badge.className = "badge bg-primary";

            const ProductCount = document.createTextNode(adet);

            badge.appendChild(ProductCount);

            satır.append(badge);

            sepetList.append(satır);
        } else {

        }
    } else {
        products.push({ name: ürünIsmı, adet: adet });
        const satır = document.createElement("li");
        const badge = document.createElement("span");

        satır.className = "list-group-item d-flex justify-content-between align-items-center";
        satır.id = "item-" + ürünIsmı.split(" ");
        const ProductName = document.createTextNode(ürünIsmı);

        satır.appendChild(ProductName);
        badge.className = "badge bg-primary";

        const ProductCount = document.createTextNode(adet);

        badge.appendChild(ProductCount);

        satır.append(badge);

        sepetList.append(satır);
    }

}
function SepetÇıkar() {

}