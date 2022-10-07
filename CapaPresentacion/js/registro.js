let clave1 = document.querySelector("#txtClave");
let clave2 = document.querySelector("#txtClave2");

showPass = (value1) => {
    if (value1 == "password") {
        clave1.setAttribute("type", "text");
        clave2.setAttribute("type", "text");
    } else {
        clave1.setAttribute("type", "password")
        clave2.setAttribute("type", "password")
    }
}
document.querySelector(".input-check-show-pass").onclick = () => {
    showPass(clave1.type, clave2.type);
}