        function populateTable() {
            var serviceTarget = "Search/";
            var searchBox = document.getElementById("searchBox");
            var teamSelect = document.getElementById("teamFramework");

            serviceTarget += searchBox.value.replace(":","|")
                +teamSelect.options[teamSelect.selectedIndex].value;

            if (serviceTarget == "Search/") {
                serviceTarget = "AgileFrameworks";
            }
      
            $.get("ScalingScrumService.svc/"+serviceTarget, function (data) {
                // Find table container div and clear it
                var tableDiv = document.getElementById("tableContainer");
                tableDiv.innerHTML = '';

                // Create a table element
                var table = document.createElement('TABLE');
                table.border = 1;
                table.cellSpacing = 0;
                table.className = "frameworkTable";

                // Create a table body element and add it to the table
                var tableBody = document.createElement('TBODY');
                table.appendChild(tableBody);

                var tableHeaderRow = document.createElement('TR');
                var tableHeader1 = document.createElement('TH');
                tableHeader1.width = '200';
                tableHeader1.appendChild(document.createTextNode('Framework Name'));
                tableHeaderRow.appendChild(tableHeader1);
                var tableHeader2 = document.createElement('TH');
                tableHeader2.width = '50';
                tableHeader2.appendChild(document.createTextNode('Link'));
                tableHeaderRow.appendChild(tableHeader2);
                var tableHeader3 = document.createElement('TH');
                tableHeader3.width = '300';
                tableHeader3.appendChild(document.createTextNode('Description'));
                tableHeaderRow.appendChild(tableHeader3);
                var tableHeader4 = document.createElement('TH');
                tableHeader4.width = '200';
                tableHeader4.appendChild(document.createTextNode('Team Framework'));
                tableHeaderRow.appendChild(tableHeader4);
                tableBody.appendChild(tableHeaderRow);

                $.each(data, function (i, val) {
                    var tableFrameworkRow = document.createElement('TR');
                    var tableCellName = document.createElement('TD');
                    tableCellName.width = '200';
                    tableCellName.appendChild(document.createTextNode(val.name));
                    tableFrameworkRow.appendChild(tableCellName);
                    var tableCellLink = document.createElement('TD');
                    tableCellLink.width = '50';
                    var linkElem = document.createElement('A');
                    linkElem.href = val.link;
                    linkElem.innerText = "Link";
                    tableCellLink.appendChild(linkElem);
                    tableFrameworkRow.appendChild(tableCellLink);
                    var tableCellDesc = document.createElement('TD');
                    tableCellDesc.width = '300';
                    tableCellDesc.appendChild(document.createTextNode(val.description));
                    tableFrameworkRow.appendChild(tableCellDesc);
                    var tableCellTeam = document.createElement('TD');
                    tableCellTeam.width = '200';
                    var teamFill = val.teamFramework;
                    if (val.teamFrameworkNote) {
                        teamFill = val.teamFrameworkNote;
                    }
                    tableCellTeam.appendChild(document.createTextNode(teamFill));
                    tableFrameworkRow.appendChild(tableCellTeam);
                    tableBody.appendChild(tableFrameworkRow);
                });

                tableContainer.appendChild(table);
            });
        }

        function populateTable2() {
            var serviceTarget = "Search/";
            var searchBox = document.getElementById("searchBox");
            var teamSelect = document.getElementById("teamFramework");

            serviceTarget += searchBox.value.replace(":","|")
                +teamSelect.options[teamSelect.selectedIndex].value;

            if (serviceTarget == "Search/") {
                serviceTarget = "AgileFrameworks";
            }
      
            $.get("ScalingScrumService.svc/"+serviceTarget, function (data) {
                // Find table container div and clear it
                var tableDiv = document.getElementById("tableContainer");
                tableDiv.innerHTML = '';

                // Create a table element
                var table = document.createElement('TABLE');
                table.border = 1;

                // Create a table body element and add it to the table
                var tableBody = document.createElement('TBODY');
                table.appendChild(tableBody);

                var columnWidth= 1000 / data.length+1;

                // Header Row
                var tableHeaderRow = document.createElement('TR');
                var tableHeader1 = document.createElement('TH');
                tableHeader1.width = columnWidth;
                tableHeader1.appendChild(document.createTextNode('Framework Name'));
                tableHeaderRow.appendChild(tableHeader1);

                $.each(data, function (i, val) {
                	var tableHeaderDyn = document.createElement('TH');
                	tableHeaderDyn.width = columnWidth;
                	tableHeaderDyn.appendChild(document.createTextNode(val.name));
                	tableHeaderRow.appendChild(tableHeaderDyn);
                });
                tableBody.appendChild(tableHeaderRow);

                // Link Row
                var tableLinkRow = document.createElement('TR');
                var tableLinkTitle = document.createElement('TD');
                tableLinkTitle.width = columnWidth;
                tableLinkTitle.appendChild(document.createTextNode('Website'));
                tableLinkRow.appendChild(tableLinkTitle);

                $.each(data, function (i, val) {
                	var tableLinkCell = document.createElement('TD');
                	tableLinkCell.width = columnWidth;
					var linkElem = document.createElement('A');
                    linkElem.href = val.link;
                    linkElem.innerText = "Link";
                    tableLinkCell.appendChild(linkElem);
                	tableLinkRow.appendChild(tableLinkCell);
                });
                tableBody.appendChild(tableLinkRow);

                // Description Row
                var tableDescRow = document.createElement('TR');
                var tableDescTitle = document.createElement('TD');
                tableDescTitle.width = columnWidth;
                tableDescTitle.appendChild(document.createTextNode('Description'));
                tableDescRow.appendChild(tableDescTitle);

                $.each(data, function (i, val) {
                	var tableDescCell = document.createElement('TD');
                	tableDescCell.width = columnWidth;
                	tableDescCell.appendChild(document.createTextNode(val.description));
                	tableDescRow.appendChild(tableDescCell);
                });
                tableBody.appendChild(tableDescRow);

                // Team Framework Row
                var tableTeamRow = document.createElement('TR');
                var tableTeamTitle = document.createElement('TD');
                tableTeamTitle.width = columnWidth;
                tableTeamTitle.appendChild(document.createTextNode('Framework Support'));
                tableTeamRow.appendChild(tableTeamTitle);

                $.each(data, function (i, val) {
                	var tableTeamCell = document.createElement('TD');
                	tableTeamCell.width = columnWidth;
                    var teamFill = val.teamFramework;
                    if (val.teamFrameworkNote) {
                        teamFill = val.teamFrameworkNote;
                    }
                    tableTeamCell.appendChild(document.createTextNode(teamFill));
                	tableTeamRow.appendChild(tableTeamCell);
                });
                tableBody.appendChild(tableTeamRow);

                tableContainer.appendChild(table);
            });
        }