export class SpruchDesTages {
    constructor(sdtUI, apiUrl) {
        this.sdt = null;
        this.sdtUI = sdtUI;
        this.uri = apiUrl;

        this.init();
    }

    init() {
        this.getSdt().then(data => {
            console.table(data);
            this.sdt = data;
            this.displayUI();
        }).catch(this.handleErrors);
    }

    async getSdt() {
        let response;

        try {
            response = await fetch(this.uri);

            if (!response.ok) {
                this.handleErrors(response.statusText);
            }

        } catch (e) {
            this.handleErrors(e);
        }

        return await response.json();
    }

    displayUI() {
        if (this.sdt) {
            this.sdtUI.spruch.innerHTML = this.sdt.spruchText;
            this.sdtUI.autorname.innerHTML = this.sdt.autorName;
            this.sdtUI.autorbeschreibung.innerHTML = this.sdt.autorBeschreibung;

            this.sdtUI.autorgeburtsdatum.innerHTML = this.sdt.autorGeburtsdatum
                ? new Date(this.sdt.autorGeburtsdatum).toLocaleDateString()
                : "k.A.";

            this.sdtUI.autorbild.innerHTML = this.sdt.autorBildType
                ? `<img src='data:${this.sdt.autorBildType};base64,${this.sdt.autorBild}' />`
                : "<img src='https://via.placeholder.com/150' />";
        } else {
            this.handleErrors("Kein Spruch des Tages Objekt vorhanden");
        }
    }

    handleErrors(errorMessage) {
        console.error(errorMessage);
    }
}