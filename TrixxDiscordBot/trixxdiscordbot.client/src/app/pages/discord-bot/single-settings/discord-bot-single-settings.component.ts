import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { SingleSettingItemModel, SingleSettingType, Workscreen } from '../../../../api/models';
import { TrixxLoadingSubject } from '../../../shared/utils/trixx-loading-subject';
import { SingleSettingsService } from '../../../../api/services';

@Component({
  selector: 'app-discord-bot-single-settings',
  standalone: false,
  templateUrl: './discord-bot-single-settings.component.html',
  styleUrl: './discord-bot-single-settings.component.scss',
})
export class DiscordBotSingleSettingsComponent implements OnInit, OnDestroy {
  public readonly title = Workscreen.DiscordBotSingleSettings;
  public readonly settingTypes = Object.values(SingleSettingType);
  public readonly form = new FormGroup(
    Object.fromEntries(
      this.settingTypes.map((type) => [type, new FormControl('')]),
    ),
  );

  private destroy$ = new Subject<void>();
  public readonly loading$ = new TrixxLoadingSubject();

  constructor(
    private readonly apiService: SingleSettingsService,
    private readonly cdr: ChangeDetectorRef,
  ) {}

  ngOnInit(): void {
    this.apiService
      .apiSingleSettingsGet()
      .pipe(
        takeUntil(this.destroy$),
        this.loading$.wrap(),
      )
      .subscribe((settings) => {
        const patch = Object.fromEntries(
          settings.map((setting) => [setting.type, setting.value ?? '']),
        );
        this.form.patchValue(patch);
        this.form.markAsPristine();
        this.cdr.detectChanges();
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  public save(): void {
    const values = this.form.getRawValue();
    const body: SingleSettingItemModel[] = this.settingTypes.map((type) => ({
      type,
      value: values[type] ?? '',
    }));

    this.apiService
      .apiSingleSettingsReplacePost({ body })
      .pipe(
        takeUntil(this.destroy$),
        this.loading$.wrap(),
      )
      .subscribe(() => this.form.markAsPristine());
  }
}
