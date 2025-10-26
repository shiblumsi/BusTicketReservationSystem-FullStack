import { ApplicationConfig, importProvidersFrom, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { provideAnimations } from '@angular/platform-browser/animations';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(),
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideAnimations(),
    importProvidersFrom(BrowserAnimationsModule),
    importProvidersFrom(
      ToastrModule.forRoot({
        timeOut: 4000,
        positionClass: 'toast-bottom-right',
        preventDuplicates: true,
        progressBar: true,
        progressAnimation: 'decreasing',
        easeTime: 300,
        newestOnTop: true,
        closeButton: true,
      }))
  ]
};
