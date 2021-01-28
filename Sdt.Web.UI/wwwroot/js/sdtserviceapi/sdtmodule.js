import { SpruchDesTages } from "./spruchdestagesmodule.js";

const sdtUI = {
    spruch: document.querySelector("#spruch"),
    autorbild: document.querySelector("#bild"),
    autorname: document.querySelector("#autor"),
    autorbeschreibung: document.querySelector("#beschreibung"),
    autorgeburtsdatum: document.querySelector("#geburtsdatum")
};

const apiUrl = "https://localhost:44319/api/sprueche/randomsdt";
const spruchDesTages = new SpruchDesTages(sdtUI, apiUrl);