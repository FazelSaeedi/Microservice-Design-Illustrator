
import { of } from "rxjs";
import Swal from "sweetalert2";

export const alertPositionTypes: 'top-right' |
  'top-left' |
  'center' |
  'bottom-left' |
  'bottom-right' |
  'bottom' |
  'top-start' |
  'top' = 'top';

export class Alert {

  /**
   * @param position  //? position of the alert
   * @param text //? text of the alert
   * @param icon //? icon of the alert ex: <img src="../../assets/images/alert-warning-icon.svg">
   * @param back //? background of the alert
   */

  public fireSuccess(position: typeof alertPositionTypes, text: string) {
    Swal.fire({
      position: window.screen.width > 540.02 ? 'bottom' : position, // ? check for desktop mode
      title: "<h6 style='color:white'>" + text + "</h6>",
      showConfirmButton: false,
      background: '#23C3FF',
      toast: true,
      iconColor: 'white',
      timer: 2000,
      width: 450,
      padding: 20,
      icon: 'success',
      // iconHtml: '<img src="../../assets/images/alert-warning-icon.svg">',
      customClass: {
        popup: 'alert-popup',
        icon: 'alert-icon',
        title: 'x',
      },
    });
  }

  public fireError(position: typeof alertPositionTypes, text: string) {
    Swal.fire({
      position: window.screen.width > 540.02 ? 'bottom' : position, // ? check for desktop mode
      title: "<h6 style='color:white'>" + text + "</h6>",
      showConfirmButton: false,
      background: '#FF8C82',
      toast: true,
      iconColor: 'white',
      timer: 2000,
      width: 450,
      padding: 20,
      iconHtml: '<img src="../../assets/images/alert-warning-icon.svg">',
      customClass: {
        popup: 'alert-popup',
        icon: 'alert-icon',
        title: 'x',
      },
    });
  }

  public async confirmAlert(title: string, description: string, confirmText: string, cancelText: string, icon?: string): Promise<any> {
    try
    {
      const resultData = await Swal.fire({
        title: title,
        text: description,
        iconHtml: `<div style = 'display : flex ; justify-content : center; align-items : center; width: 144px ; height : 144px; border-radius : 50%; background :linear-gradient(180deg, rgba(255, 225, 220, 0.5) -12.67%, rgba(255, 225, 220, 0) 75%)'>
        <img style = 'width: 94px ; height : 94px;' src="../../assets/images/confirm-alert-image/${icon}.svg">
         </div>`,
        customClass: {
          title: 'titleConfirmAlert-class',
        },
        // icon: 'warning',
        padding: '25px',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: cancelText,
        confirmButtonText: confirmText,
        reverseButtons: true,
      });
      return of(resultData.isConfirmed).toPromise();
    } catch (error)
    {

    }
    return;
  }

}