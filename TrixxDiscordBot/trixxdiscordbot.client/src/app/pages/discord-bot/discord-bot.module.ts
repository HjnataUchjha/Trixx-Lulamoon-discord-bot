import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { NbButtonModule, NbCardModule, NbInputModule } from '@nebular/theme';
import { SharedModule } from '../../shared/modules/shared.module';
import { DiscordBotSingleSettingsComponent } from './single-settings/discord-bot-single-settings.component';
import { DiscordBotRoutingModule } from './discord-bot-routing.module';

@NgModule({
  declarations: [
    DiscordBotSingleSettingsComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    DiscordBotRoutingModule,
    NbCardModule,
    NbButtonModule,
    NbInputModule,
    ReactiveFormsModule,
  ],
})
export class DiscordBotModule {}
