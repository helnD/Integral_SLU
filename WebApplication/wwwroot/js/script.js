function addElement(string) {
    var field = document.getElementById("func-field");
    field.value += string;
}

function clearForm() {
    document.getElementById("sup").value = "";
    document.getElementById("sub").value = "";
    document.getElementById("result").innerHTML = "";
    document.getElementById("func-field").value = "";
    document.getElementById("range-value").value = "";
}

function setValue() {
    let sup = document.getElementById("sup").value;
    let sub = document.getElementById("sub").value;
    let range = document.getElementById("range-value");

    if (sup != "" && sub != "") {
        range.value = sup - sub;
    }
}

function increaseValue(val) {
    document.getElementById("range-value").value *= val;
}

function addEquation() {
    var equations = document.getElementById("equations-form").getElementsByClassName("equation");
    var numberOfEq = equations.length;

    let div = createEquation(numberOfEq);
    div.className = "equation eq-" + (numberOfEq + 1);

    var button = document.getElementsByClassName("control-buttons")[0];
    button.before(div);

    equations = document.getElementById("equations-form").getElementsByClassName("equation");
    numberOfEq = equations.length;

    for (let i = 0; i < numberOfEq; i++) {
        let span1 = document.createElement("span");
        span1.innerHTML = "&#160;x" + numberOfEq;
        let span2 = document.createElement("span");
        span2.innerHTML = "+&#160;";

        let input = document.createElement("input");
        input.type = "text";
        input.id = "a" + (numberOfEq * numberOfEq + 1);

        eq = equations[i];
        let sign = eq.getElementsByClassName("equal-sign")[0];
        sign.before(span2, input, span1);
    }
}

function createEquation(numberOfVars) {
    let div = document.createElement("div");

    for (let i = 0; i < numberOfVars - 1; i++) {
        let input = document.createElement("input");
        //input.id = "a";
        input.type = "text";

        let span = document.createElement("span");
        span.innerHTML = "&#160;x" + (i + 1) + "+&#160;";

        div.append(input, span);
    }

    let input1 = document.createElement("input");
    //input.id = "a";
    input1.type = "text";

    let span1 = document.createElement("span");
    span1.innerHTML = "&#160;x" + (numberOfVars);
    let span2 = document.createElement("span");
    span2.innerHTML = "=&#160;";
    span2.className = "equal-sign";

    let input2 = document.createElement("input");
    //input.id = "b";
    input2.type = "text";

    div.append(input1, span1, span2, input2);

    return div;
}

function clearEqForm() {
    let equations = document.getElementById("equations-form").getElementsByClassName("equation");

    for (let i = 0; i < equations.length; i++) {
        let inputs = equations[i].getElementsByTagName("input");
        for (let j = 0; j < inputs.length; j++) {
            inputs[j].value = "";
        }
    }
}

function deleteEquation() {
    let form = document.getElementById("equations-form");
    let equations = form.getElementsByClassName("equation");
    let length = equations.length;

    if (length - 1 >= 2) {
        form.removeChild(equations[length - 1]);

        for (let j = 0; j < equations.length; j++) {
            let children = equations[j].children;
            for (let i = 0; i < children.length; i++) {
                let child = children[i];
                if (child.className == "equal-sign") {
                    equations[j].removeChild(children[i - 1]);
                    equations[j].removeChild(children[i - 2]);
                    equations[j].removeChild(children[i - 3]);
                }
            }
        }
    }
}

function sendIntegrationForm() {

      var sup_limit = document.getElementById("sup");
      var sub_limit = document.getElementById("sub");
      var range = document.getElementById("range-value");
      var func = document.getElementById("func-field");
      var meth = document.getElementById("meth1").checked ? "method1" : "method2";

      var request = new XMLHttpRequest();
      var body =
          "side=left"
          + "&sup=" + encodeURIComponent(sup_limit.value)
          + "&sub=" + encodeURIComponent(sub_limit.value)
          + "&func=" + encodeURIComponent(func.value)
          + "&range=" + encodeURIComponent(range.value)
          + "&meth=" + encodeURIComponent(meth);

      request.open("GET", "https://localhost:5001/Home/Index?" + body, false);
      request.send();

      var result_label = document.getElementById("result-value");
      result_label.innerHTML = "";
      result_label.appendChild(document.createTextNode(request.response));
}

function sendEquationsForm() {
    var request = new XMLHttpRequest;
    var body = "side=right&";

    let equations = document.getElementsByClassName("equation");
    let varIndex = 1;

    for (let j = 0; j < equations.length; j++) {
        let inputs = equations[j].getElementsByTagName("input");

        for (let i = 0; i < inputs.length - 1; i++) {
            body += "a" + varIndex + "="
                + (inputs[i].value != "" ? inputs[i].value : 0) + "&";
            varIndex++;
        }
        body += "b" + (j + 1) + "="
            + (inputs[inputs.length - 1].value != "" ? inputs[inputs.length - 1].value : 0);
        body += (j == equations.length - 1 ? "" : "&");
    }

    console.log(body);

    request.open("GET", "https://localhost:5001/Home/Index?", false);
    request.send(body);
}
