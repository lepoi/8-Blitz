<%@ Page Title="Create a Blitz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listen.aspx.cs" Inherits="_8_blitz._Listen" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<script src="https://code.jquery.com/jquery-3.3.1.min.js" integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8=" crossorigin="anonymous"></script>
	<script src="/Scripts/tone.js"></script>

	<style type="text/css">
		.sel {
			background: green;
		}

		.sq {
			width: 80px;
			height: 70px;
			margin: 5px;
		}
	</style>

	<h2><%= BlitzName %></h2>

	<div class="row">
		<div class="col-xs-8 col-xs-offset-2">
			<table border="1" id="grid">
				<tbody>
					<tr>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					</tr>
					<tr>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					</tr>
					<tr>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					</tr>
					<tr>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					</tr>
					<tr>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					</tr>
					<tr>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					<td><div class="sq"></div></td>
					</tr>
					<tr>
				<td><div class="sq"></div></td>
				<td><div class="sq"></div></td>
				<td><div class="sq"></div></td>
				<td><div class="sq"></div></td>
				<td><div class="sq"></div></td>
				<td><div class="sq"></div></td>
				<td><div class="sq"></div></td>
				<td><div class="sq"></div></td>
				<td><div class="sq"></div></td>
				<td><div class="sq"></div></td>
				</tr>
				</tbody>
			</table>

			<button type="button" id="play" class="btn btn-default">Play</button>

			<script type="text/javascript">
					const synth = new Tone.Synth().toMaster();
					const dur = '4n';
					const notes = ['C', 'D', 'E', 'F', 'G', 'A', 'B'];
					const tempo = 200;
					var current_time;
					var playing = null;
					var state;
					var example_state = "";

					get_pos = (td) => {
						let time = parseInt($(td).index());
						let note = parseInt($(td).parent().index());

						return {
							time: time,
							note: note
						}
					}

					set_state = (state) => {
						let i = state.split(" ");
						$("#grid tr").each(function() {
							$('td', this).each(function() {
		    						$(this).removeClass("sel");

		    						let s = i.shift();
		    						if (s == "true") {
		        					$(this).addClass("sel");
		    						}
							 });
						});
					}

					play_note = (note) => {
						synth.triggerAttackRelease(notes[note] + '4', dur);
					}

					play_time = () => {
						console.log("playing");
						$("#grid tr").each(function(index) {
							$('td', this).each(function(index2) {
		    						if (index2 != current_time) {
		    							return;
		    						}

		    						let value = $(this).hasClass('sel');
		    						if (value)
		    							play_note(index);
							 });
						});
					}

					next_time = () => {
						current_time++;
						if (current_time >= 10) {
							current_time = 0;
						}
					}

					update_state = () => {
						state = "";
						$("#grid tr").each(function(index) {
							$('td', this).each(function(index2) {
		    						let value = $(this).hasClass('sel');
		    						state += value + " ";
							 });
						});
						$("#MainContent_blitzContent").text(state);
						$("#MainContent_blitzContent").val(state);
					}

					$(document).ready(function() {
	 					$('#grid tbody').on('click', 'td', function() {   
						let pos = get_pos(this);
						console.log(`time: ${pos.time}, note: ${pos.note}`);
							$(this).toggleClass('sel');

							play_note(pos.note);
							update_state();
					  });

	 					$('#play').on('click', function() {
	 						if (playing == null) {
	 							current_time = 0;
	 							$(this).text("Stop");
		 						playing = setInterval(function() {
		 							play_time();
		 							next_time();
		 						}, tempo);
		 					} else {
		 						$(this).text("Play");
		 						clearInterval(playing);
		 						playing = null;
		 					}
						});
					});

					set_state("<%= BlitzContent %>");
				</script>
		</div>
	</div>



</asp:Content>