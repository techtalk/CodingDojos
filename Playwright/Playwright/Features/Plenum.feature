Feature: Plenum Playwright Tests fuer Techday

Scenario: 1. Sitzung erstellen
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	When der Benutzer die Sitzung 'GX-Playwright-Sitzung' mit der Sitzungsart 'GX_Gemeinderatssitzung' erstellt
	Then sollte eine Sitzung 'GX-Playwright-Sitzung' mit der Sitzungsart 'GX_Gemeinderatssitzung' existieren

Scenario: 2. Teilnehmer in vorhandener Sitzung hinzufügen
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	And der Benutzer sich auf der Startseite befindet
	And der Benutzer die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' öffnet
	When der Benutzer den vorhandenen Teilnehmer 'Verena Muster' hinzufügt
	Then sollte die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' den Teilnehmer 'Verena Muster' hinterlegt haben

Scenario: 3. Erstelle Tagesordnungspunkte und füge diesen einer Sitzung hinzu
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	And der Benutzer sich auf der Startseite befindet
	When der Benutzer einen neuen Tagesordnungspunkt 'GX_TOP' erstellt
	And der Benutzer die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' öffnet
	And diesen Tagesordnungspunkt 'GX_TOP' zuordnet
	Then sollte dieser Tagesordnungspunkt 'GX_TOP' in der Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' existieren

Scenario: 4. Erstelle Tagesordnungspunkte in Sitzung
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	And der Benutzer sich auf der Startseite befindet
	When der Benutzer die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' öffnet
	And der Benutzer einen neuen Tagesordnungspunkt 'GX_TOP2' anlegt
	Then sollte dieser Tagesordnungspunkt 'GX_TOP2' in der Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' existieren

Scenario: 5. Erstelle Kommentar in Tagesordnungspunkte in Sitzung
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	And der Benutzer sich auf der Startseite befindet
	And der Benutzer die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' öffnet
	And der Benutzer den Tagesordnungspunkt 'GX_TOP' öffnet
	When der Benutzer einen Kommentar 'kommentar' anlegt
	Then sollte dieser Kommentar 'kommentar' auf dem Tagesordnungspunkt 'GX_TOP' in der Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' existieren

Scenario: 6. Ändere den Status eines Tagesordnungspunkts auf 'Abgeschlossen'
	Given der Benutzer ist auf der Plenum Homepage
	And dieser Benutzer loggt sich ein
	And der Benutzer sich auf der Startseite befindet
	And der Benutzer die Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' öffnet
	And der Benutzer den Tagesordnungspunkt 'GX_TOP' öffnet
	When der Benutzer den Status auf 'Beschlossen' ändert
	Then sollte der Tagesordnungspunkt 'GX_TOP' in der Sitzung mit der Sitzungsart 'GX_Gemeinderatssitzung' den Status 'Beschlossen' haben