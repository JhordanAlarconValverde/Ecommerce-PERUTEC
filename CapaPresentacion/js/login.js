var eye = document.querySelector(".fa-eye-slash");
var clave = document.querySelector("#txtClave");

cambiarPass = (value) => {
    if (value == "fa-eye-slash") {
        eye.classList.remove("fa-eye-slash");
        eye.classList.add("fa-eye");
        clave.setAttribute("type", "text");
    } else {
        eye.classList.remove("fa-eye");
        eye.classList.add("fa-eye-slash");
        clave.setAttribute("type", "password");
    }
}

eye.onclick = () => {
    cambiarPass(eye.classList[1], clave);
}