Feature: Plenum Playwright Tests fuer Techday

Scenario: Sitzung erstellen
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	When der Benutzer die Sitzung 'GX-Playwright-Sitzung' mit der Sitzungsart 'GX_Gemeinderatssitzung' erstellt
	Then sollte eine Sitzung 'GX-Playwright-Sitzung' mit der Sitzungsart 'GX_Gemeinderatssitzung' existieren

Scenario: Teilnehmende in vorhandener Sitzung hinzufügen
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	And der Benutzer sich auf der Startseite befindet
	And der Benutzer die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' öffnet
	When der Benutzer den vorhandenen Teilnehmer 'Verena Muster' hinzufügt
	Then sollte die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' den Teilnehmer 'Verena Muster' hinterlegt haben

Scenario: Erstelle Tagesordnungspunkte und füge diesen einer Sitzung hinzu
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	And der Benutzer sich auf der Startseite befindet
	When der Benutzer einen neuen Tagesordnungspunkt 'GX_TOP' erstellt
	And der Benutzer die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' öffnet
	And diesen Tagesordnungspunkt 'GX_TOP' zuordnet
	Then sollte dieser Tagesordnungspunkt 'GX_TOP' existieren

Scenario: Erstelle Tagesordnungspunkte in Sitzung
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	And der Benutzer sich auf der Startseite befindet
	When der Benutzer die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' öffnet
	And der Benutzer einen neuen Tagesordnungspunkt 'GX_TOP2' anlegt
	Then sollte dieser Tagesordnungspunkt 'GX_TOP' in der Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' existieren

Scenario: Erstelle Kommentar in Tagesordnungspunkte in Sitzung
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	And der Benutzer sich auf der Startseite befindet
	And der Benutzer die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' öffnet
	And der Benutzer den Tagesordnungspunkt 'GX_TOP' öffnet
	When der Benutzer einen Kommentar 'kommentar' anlegt
	Then sollte dieser Kommentar 'kommentar' sich auf dem Tagesordnungspunkt befinden

Scenario: Ändere den Status eines Tagesordnungspunkts auf 'Abgeschlossen'
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	And der Benutzer sich auf der Startseite befindet
	And der Benutzer die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' öffnet
	And der Benutzer den Tagesordnungspunkt 'GX_TOP' öffnet
	When der Benutzer den Status auf 'Beschlossen' ändert
	Then sollte der Tagesordnungspunkt 'GX_TOP' den Status 'Beschlossen' haben

Scenario: Zeige Abgeschlossene Sitzungen
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	And der Benutzer sich auf der Startseite befindet
	When der Benutzer 'abgeschlossene Sitzungen anzeigen' anklickt
	Then sollte er alle abgeschlossene Sitzungen sehen