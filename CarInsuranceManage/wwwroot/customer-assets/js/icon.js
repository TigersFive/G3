const BtnShowPass = document.querySelector("#show-pass");
const inputPass = document.querySelector("#input-pass");
const BtnShowConfirmPass = document.querySelector("#show-confirm-pass");
const inputConfirmPass = document.querySelector("#input-confirm-pass");

BtnShowPass.addEventListener("click", function () {
  // Toggle lớp 'active' cho biểu tượng mắt
  BtnShowPass.classList.toggle("active");

  // Kiểm tra và thay đổi type của input
  if (inputPass.type === "password") {
    inputPass.type = "text"; // Hiển thị mật khẩu
  } else {
    inputPass.type = "password"; // Ẩn mật khẩu
  }
});

BtnShowConfirmPass.addEventListener("click", function () {
  // Toggle lớp 'active' cho biểu tượng mắt
  BtnShowConfirmPass.classList.toggle("active");

  // Kiểm tra và thay đổi type của input
  if (inputConfirmPass.type === "password") {
    inputConfirmPass.type = "text"; // Hiển thị mật khẩu
  } else {
    inputConfirmPass.type = "password"; // Ẩn mật khẩu
  }
});
