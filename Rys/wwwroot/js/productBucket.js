//Artı ve eksi butonlarının hepsi
const buttons = document.querySelectorAll(".btn-counter");

//Değer Aralığı
const minValue = 0;
const maxValue = 10;

//Sepetin html etiketi
const bucket = document.querySelector("body > div.layout-wrapper.layout-content-navbar > div.layout-container > div > div > div.container-xxl.flex-grow-1.container-p-y > div > div.col-md-4 > div > div.card-body > ul");
//Sepetteki ürünleri tutacak dizi
const products = new Array();

//Butona tıklandığında
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

        // 5. Ürün ismi alma
        const areaparent = parent.parentNode;
        const productInfoArea = areaparent.querySelector(".title-product");
        const productName = productInfoArea.querySelector(".label-product").textContent;

        // 6. Tıklanılan butonun artı veya eksi olma durumu
        var newNumber = number;
        if (element.classList.contains("plus")) {
            newNumber = number + 1;
            bucketAdd(productName);
        } else {
            newNumber = number - 1;
            bucketRemove(productName);
        }
        console.table(products);

        // 7. Yeni sayıyı atama inputa atama
        numberContainer.textContent = newNumber;

        // 8. Değer aralığını kontrol etme
        if (newNumber === minValue) {
            decrement.disabled = true;
            numberContainer.classList.add("dim");
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
    });
});

function bucketAdd(productName) {
    products.push(productName);
    var count = products.filter(p => p === productName).length;
    bucketListAdd(productName, count);
}

function bucketRemove(productName) {

    for (var i = 0; i < products.length; i++) {
        if (products[i] === productName) {
            products.splice(products.indexOf(productName), 1);
            bucketListRemove(productName, count);
            break;
        }
    }

}

function bucketListAdd(name, count) {
    const satır = document.createElement("li");
    const badge = document.createElement("span");

    satır.className = "list-group-item d-flex justify-content-between align-items-center";
    badge.className = "badge bg-primary";


    if (count > 1) {//ürün listede varsa
        for (var i = 0; i < bucket.children.length; i++) {
            if (bucket.children[i].childNodes[0].textContent == name) {
                bucket.children[i].children[0].innerHTML = count;
            }
        }
    }
    else {

        const ProductName = document.createTextNode(name);
        satır.appendChild(ProductName);

        const ProductCount = document.createTextNode(count);

        badge.appendChild(ProductCount);

        satır.append(badge);

        bucket.append(satır);
    }
}
function bucketListRemove(name, count) {
    if (products.length > 0) {
        eklensin = false;

        products.forEach((product) => {
            if (product.name == ürünIsmı) {
                product.adet = -1;
                eklensin = true;
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
            document.getElementById("item-" + ürünIsmı.split(" ")).children[0].innerHTML = adet;
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