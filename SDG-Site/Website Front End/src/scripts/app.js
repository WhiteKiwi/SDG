function showNav() {
  console.log("this is working");
  var x = document.getElementById("responsive-nav");
  if (x.className === "responsive-nav") {
    x.className += " unfold";
  } else {
    x.className = "responsive-nav";
  }
}

function showSolutions() {
  console.log("this is working");
  var x = document.getElementById("responsive-solution");
  if (x.className === "responsive-solution") {
    x.className += "reveal";
  } else {
    x.className = "responsive-solution";
  }
}
