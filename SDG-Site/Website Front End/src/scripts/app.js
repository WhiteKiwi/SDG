function showNav() {
  console.log("this is working");
  var x = document.getElementById("responsive-nav");
  if (x.className === "responsive-nav") {
    x.className += " unfold";
  } else {
    x.className = "responsive-nav";
  }
}

function showSolution() {
  console.log("this is working");
  var x = document.getElementById("solution");
  if (x.className === "stage") {
    x.className += " show-solutions";
  } else {
    x.className = "stage";
  }
}

function showSolution() {
  console.log("this is working");
  var x = document.getElementsByClassName("solution");
  if (x.className === "solution") {
    x.className += " show-solutions";
  } else {
    x.className = "solution";
  }
}

function showSolution() {
  console.log("this is working");
  var x = document.getElementsByClassName("date-submitted");
  if (x.className === "date-submitted") {
    x.className += " show-solutions";
  } else {
    x.className = "date-submitted";
  }
}
