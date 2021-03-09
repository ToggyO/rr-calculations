export interface IButtonProps {
  onClick?: (...args: any[]) => any;
  text?: React.ReactNode | React.ReactText;
  type?: 'button' | 'submit' | 'reset';
  disabled?: boolean;
}
