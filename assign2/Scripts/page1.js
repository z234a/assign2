function updateTime() {
    var now = new Date();
    var hours = now.getHours();
    var minutes = now.getMinutes();
    var seconds = now.getSeconds();
    hours = hours < 10 ? "0" + hours : hours;
    minutes = minutes < 10 ? "0" + minutes : minutes;
    seconds = seconds < 10 ? "0" + seconds : seconds;
    var timeString = hours + ":" + minutes + ":" + seconds;
    document.getElementById("clock").innerHTML = timeString;
}
setInterval(updateTime, 1000);

  var form = document.getElementById('myForm');
  form.addEventListener('submit', function(event) {
      event.preventDefault(); // 阻止表单默认提交行为
      var username = form.elements.username.value;
      alert('Thank you for your feedback: ' + username);
  });