import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DiscordBotSingleSettingsComponent } from './single-settings/discord-bot-single-settings.component';

const routes: Routes = [
    {
        path: 'single-settings',
        pathMatch: 'full',
        component: DiscordBotSingleSettingsComponent,
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class DiscordBotRoutingModule {}
