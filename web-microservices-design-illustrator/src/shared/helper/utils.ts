export const FaNumbers = ['۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹'];
export const EnNumbers = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

// ? Replace Farsi Numbers With English
export function replaceFaNumbers(text: string) {
    if (text)
    {
        var result = text.replace(/./g, function (char) {
            var idx = FaNumbers.indexOf(char);
            return idx > -1 ? EnNumbers[idx] : char;
        });
        return result;

    }
    else return;
}