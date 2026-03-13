use std::num::ParseIntError;

const MIN_BOUND: u16 = 0;
const MAX_BOUND: u16 = 99;

struct Rotation {
    new_position: u16,
    passed_zero: u16,
}

pub struct DayResult {
    pub landed_on_zero: u16,
    pub passed_zero: u16,
}

pub fn run(input: String, start_position: u16) -> DayResult {
    let mut landed_on_zero: u16 = 0;
    let mut passed_zero: u16 = 0;
    let mut position = start_position;
    for line in input.split('\n').into_iter() {
        if line.trim().is_empty() {
            continue;
        }
        let maybe_signed_int = to_signed_int(line.to_string());

        let signed_int = match maybe_signed_int {
            Ok(result) => result,
            Err(error) => {
                println!("Could not parse {} as i16. Error: {}", line, error);
                return DayResult {
                    landed_on_zero: 0,
                    passed_zero: 0,
                };
            }
        };

        if signed_int == 0 {
            continue;
        }

        let rotation = if signed_int < 0 {
            rotate_left(position, signed_int.abs() as u16)
        } else {
            rotate_right(position, signed_int as u16)
        };
        if rotation.new_position == 0 {
            landed_on_zero += 1;
        }
        passed_zero += rotation.passed_zero;

        println!(
            "{} -> {}. pos: {} -> {}",
            line, signed_int, position, rotation.new_position
        );
        position = rotation.new_position;
    }

    return DayResult {
        landed_on_zero: landed_on_zero,
        passed_zero: passed_zero,
    };
}

fn to_signed_int(rotation: String) -> Result<i16, ParseIntError> {
    let signed_string = rotation.trim().replace("L", "-").replace("R", "");
    signed_string.parse::<i16>()
}

/// Takes a start position and a number of steps, returns a new position
fn rotate_right(start_position: u16, steps: u16) -> Rotation {
    let mut position = start_position;
    let mut passed_zero = 0;
    for i in 0..steps {
        position += 1;
        if position > MAX_BOUND {
            position = 0;
        }
        if position == 0 && i < steps - 1 {
            passed_zero += 1;
        }
    }
    Rotation {
        new_position: position as u16,
        passed_zero,
    }
}

/// Takes a start position and a number of steps, returns a new position
fn rotate_left(start_position: u16, steps: u16) -> Rotation {
    let mut position = start_position as i16;
    let mut passed_zero = 0;
    for i in 0..steps {
        position -= 1;
        if position < MIN_BOUND as i16 {
            position = 99;
        }
        if position == 0 && i < steps - 1 {
            passed_zero += 1;
        }
    }
    Rotation {
        new_position: position as u16,
        passed_zero,
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn run_with_one_line_returns_one() {
        let result = run("L50".to_string(), 50);
        assert_eq!(1, result.landed_on_zero);
    }

    #[test]
    fn advanced_test_case() {
        let result = run(
            "L68
L30
R48
L5
R60
L55
L1
L99
R14
L82"
            .to_string(),
            50,
        );
        assert_eq!(6, result.landed_on_zero + result.passed_zero);
    }

    #[test]
    fn converts_left_rotation_to_negative_number() {
        let maybe_signed_int = to_signed_int("L99".to_string());
        assert_eq!(-99, maybe_signed_int.unwrap());
    }
    #[test]
    fn converts_right_rotation_to_positive_number() {
        let maybe_signed_int = to_signed_int("R99".to_string());
        assert_eq!(99, maybe_signed_int.unwrap());
    }

    #[test]
    fn rotates_left() {
        assert_eq!(82, rotate_left(50, 68).new_position);
        assert_eq!(52, rotate_left(82, 30).new_position);
    }

    #[test]
    fn rotates_right() {
        assert_eq!(0, rotate_right(52, 48).new_position);
        assert_eq!(55, rotate_right(95, 60).new_position);
    }
}
